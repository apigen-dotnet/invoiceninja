using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
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
      if (AreSchemasEqual(schemas[name], schemas[canonical]))
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
      if (!b.Properties.TryGetValue(kvp.Key, out OpenApiSchema? bProp)) return false;
      if (kvp.Value.Type != bProp.Type) return false;
      if (kvp.Value.Format != bProp.Format) return false;
      if (kvp.Value.Nullable != bProp.Nullable) return false;
      if (kvp.Value.ReadOnly != bProp.ReadOnly) return false;
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
        foreach (var op in path.Operations.Values)
        {
          RewriteInOperation(op, oldName, newName);
        }
      }
    }

    // Rewrite in schemas (properties that $ref to the old name)
    if (document.Components?.Schemas != null)
    {
      foreach (var schema in document.Components.Schemas.Values)
      {
        RewriteInSchema(schema, oldName, newName);
      }
    }
  }

  private static void RewriteInOperation(OpenApiOperation operation, string oldName, string newName)
  {
    // Request body
    if (operation.RequestBody?.Content != null)
    {
      foreach (var content in operation.RequestBody.Content.Values)
      {
        if (content.Schema != null) RewriteInSchema(content.Schema, oldName, newName);
      }
    }

    // Responses
    foreach (var response in operation.Responses.Values)
    {
      if (response.Content == null) continue;
      foreach (var content in response.Content.Values)
      {
        if (content.Schema != null) RewriteInSchema(content.Schema, oldName, newName);
      }
    }
  }

  private static void RewriteInSchema(OpenApiSchema schema, string oldName, string newName)
  {
    if (schema.Reference?.Id == oldName)
    {
      schema.Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = newName };
    }

    if (schema.Properties != null)
    {
      foreach (var prop in schema.Properties.Values)
      {
        RewriteInSchema(prop, oldName, newName);
      }
    }

    if (schema.Items != null) RewriteInSchema(schema.Items, oldName, newName);

    if (schema.AllOf != null)
      foreach (var s in schema.AllOf) RewriteInSchema(s, oldName, newName);
    if (schema.OneOf != null)
      foreach (var s in schema.OneOf) RewriteInSchema(s, oldName, newName);
    if (schema.AnyOf != null)
      foreach (var s in schema.AnyOf) RewriteInSchema(s, oldName, newName);

    if (schema.AdditionalProperties != null) RewriteInSchema(schema.AdditionalProperties, oldName, newName);
  }
}
