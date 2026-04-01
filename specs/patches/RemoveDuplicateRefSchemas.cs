using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi;
using Apigen.Generator;

/// <summary>
/// Remove FooRef schemas that are identical to their Foo counterparts.
/// Rewrites all $ref pointers to use the canonical (non-Ref) schema.
/// </summary>
public class RemoveDuplicateRefSchemas : ISpecPatch
{
  public string Name => "Remove duplicate Ref schemas";

  public bool Apply(OpenApiDocument document)
  {
    if (document.Components?.Schemas == null) return false;

    var schemas = document.Components.Schemas;
    List<(string RefName, string CanonicalName)> duplicates = new();

    // Find all FooRef schemas that have a matching Foo schema
    foreach (string name in schemas.Keys.ToList())
    {
      if (!name.EndsWith("Ref")) continue;
      string canonical = name[..^3]; // "CompanyUserRef" -> "CompanyUser"
      if (!schemas.ContainsKey(canonical)) continue;

      // Compare structure: same properties, types, required fields
      // In 3.x, schemas in the dictionary are IOpenApiSchema; resolve to concrete OpenApiSchema
      OpenApiSchema aResolved = ResolveSchema(schemas[name]);
      OpenApiSchema bResolved = ResolveSchema(schemas[canonical]);
      if (AreSchemasEqual(aResolved, bResolved))
      {
        duplicates.Add((name, canonical));
      }
    }

    if (duplicates.Count == 0) return false;

    // Rewrite references and remove duplicates
    foreach (var (refName, canonicalName) in duplicates)
    {
      RewriteRefs(document, refName, canonicalName);
      schemas.Remove(refName);
    }

    return true;
  }

  private static OpenApiSchema ResolveSchema(IOpenApiSchema schema)
  {
    if (schema is OpenApiSchema concrete) return concrete;
    if (schema is OpenApiSchemaReference reference)
      return reference.RecursiveTarget ?? throw new System.InvalidOperationException(
        $"Unresolved schema reference: {reference.Reference?.Id ?? "(unknown)"}");
    return (OpenApiSchema)schema;
  }

  private static bool AreSchemasEqual(OpenApiSchema a, OpenApiSchema b)
  {
    // Compare property count
    int aCount = a.Properties?.Count ?? 0;
    int bCount = b.Properties?.Count ?? 0;
    if (aCount != bCount) return false;

    if (a.Properties == null || b.Properties == null) return aCount == 0 && bCount == 0;

    // Compare each property
    foreach (var kvp in a.Properties)
    {
      if (!b.Properties.TryGetValue(kvp.Key, out IOpenApiSchema? bPropI)) return false;
      // Resolve both to concrete schemas for comparison
      OpenApiSchema aProp = ResolveSchema(kvp.Value);
      OpenApiSchema bProp = ResolveSchema(bPropI);
      if (aProp.Type != bProp.Type) return false;
      if (aProp.Format != bProp.Format) return false;
      // In 3.x, Nullable is replaced by JsonSchemaType.Null flag
      bool aNullable = aProp.Type.HasValue && aProp.Type.Value.HasFlag(JsonSchemaType.Null);
      bool bNullable = bProp.Type.HasValue && bProp.Type.Value.HasFlag(JsonSchemaType.Null);
      if (aNullable != bNullable) return false;
      if (aProp.ReadOnly != bProp.ReadOnly) return false;
    }

    return true;
  }

  private static void RewriteRefs(OpenApiDocument document, string oldName, string newName)
  {
    // Rewrite in paths
    if (document.Paths != null)
    {
      foreach (var path in document.Paths.Values)
      {
        if (path.Operations == null) continue;
        foreach (var op in path.Operations.Values)
        {
          RewriteInOperation(document, op, oldName, newName);
        }
      }
    }

    // Rewrite in schemas (properties that $ref to the old name)
    if (document.Components?.Schemas != null)
    {
      foreach (var schema in document.Components.Schemas.Values)
      {
        RewriteInISchema(document, schema, oldName, newName);
      }
    }
  }

  private static void RewriteInOperation(OpenApiDocument document, OpenApiOperation operation, string oldName, string newName)
  {
    // Request body
    if (operation.RequestBody?.Content != null)
    {
      foreach (var content in operation.RequestBody.Content.Values)
      {
        if (content.Schema != null) RewriteContentSchema(document, content, oldName, newName);
      }
    }

    // Responses
    if (operation.Responses != null)
    {
      foreach (var response in operation.Responses.Values)
      {
        if (response.Content == null) continue;
        foreach (var content in response.Content.Values)
        {
          if (content.Schema != null) RewriteContentSchema(document, content, oldName, newName);
        }
      }
    }
  }

  private static void RewriteContentSchema(OpenApiDocument document, IOpenApiMediaType iContent, string oldName, string newName)
  {
    if (iContent is not OpenApiMediaType content) return;
    // In 3.x, if content.Schema is an OpenApiSchemaReference, check Reference.Id
    if (content.Schema is OpenApiSchemaReference schemaRef && schemaRef.Reference?.Id == oldName)
    {
      content.Schema = new OpenApiSchemaReference(newName, document);
    }
    else if (content.Schema != null)
    {
      RewriteInISchema(document, content.Schema, oldName, newName);
    }
  }

  private static void RewriteInISchema(OpenApiDocument document, IOpenApiSchema iSchema, string oldName, string newName)
  {
    // If this is a schema reference, we can't rewrite it in-place from here;
    // it should be handled by the caller (e.g., replacing dict entries).
    // Focus on concrete schema properties.
    OpenApiSchema schema;
    if (iSchema is OpenApiSchema concrete)
      schema = concrete;
    else if (iSchema is OpenApiSchemaReference)
      return; // References are handled at the collection level
    else
      return;

    if (schema.Properties != null)
    {
      // Check each property; if it's a $ref to oldName, replace it
      var keys = schema.Properties.Keys.ToList();
      foreach (var key in keys)
      {
        var prop = schema.Properties[key];
        if (prop is OpenApiSchemaReference propRef && propRef.Reference?.Id == oldName)
        {
          schema.Properties[key] = new OpenApiSchemaReference(newName, document);
        }
        else
        {
          RewriteInISchema(document, prop, oldName, newName);
        }
      }
    }

    if (schema.Items != null)
    {
      if (schema.Items is OpenApiSchemaReference itemsRef && itemsRef.Reference?.Id == oldName)
      {
        schema.Items = new OpenApiSchemaReference(newName, document);
      }
      else
      {
        RewriteInISchema(document, schema.Items, oldName, newName);
      }
    }

    RewriteInSchemaList(document, schema.AllOf, oldName, newName);
    RewriteInSchemaList(document, schema.OneOf, oldName, newName);
    RewriteInSchemaList(document, schema.AnyOf, oldName, newName);

    if (schema.AdditionalProperties != null)
    {
      if (schema.AdditionalProperties is OpenApiSchemaReference addPropsRef && addPropsRef.Reference?.Id == oldName)
      {
        schema.AdditionalProperties = new OpenApiSchemaReference(newName, document);
      }
      else
      {
        RewriteInISchema(document, schema.AdditionalProperties, oldName, newName);
      }
    }
  }

  private static void RewriteInSchemaList(OpenApiDocument document, IList<IOpenApiSchema>? list, string oldName, string newName)
  {
    if (list == null) return;
    for (int i = 0; i < list.Count; i++)
    {
      if (list[i] is OpenApiSchemaReference listRef && listRef.Reference?.Id == oldName)
      {
        list[i] = new OpenApiSchemaReference(newName, document);
      }
      else
      {
        RewriteInISchema(document, list[i], oldName, newName);
      }
    }
  }
}
