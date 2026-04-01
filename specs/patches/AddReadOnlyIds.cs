using Microsoft.OpenApi;
using Apigen.Generator;

/// <summary>
/// Add readOnly: true to 'id' properties on all component schemas.
/// </summary>
public class AddReadOnlyIds : ISpecPatch
{
  public string Name => "Add readOnly to id fields";

  public bool Apply(OpenApiDocument document)
  {
    if (document.Components?.Schemas == null) return false;

    int count = 0;
    foreach (var iSchema in document.Components.Schemas.Values)
    {
      // In 3.x, values are IOpenApiSchema; resolve to concrete OpenApiSchema
      OpenApiSchema schema = ResolveSchema(iSchema);
      count += PatchSchema(schema);
    }

    return count > 0;
  }

  private static OpenApiSchema ResolveSchema(IOpenApiSchema schema)
  {
    if (schema is OpenApiSchema concrete) return concrete;
    if (schema is OpenApiSchemaReference reference)
      return reference.RecursiveTarget ?? throw new System.InvalidOperationException(
        $"Unresolved schema reference: {reference.Reference?.Id ?? "(unknown)"}");
    return (OpenApiSchema)schema;
  }

  private static int PatchSchema(OpenApiSchema schema)
  {
    int count = 0;

    // In 3.x, Properties is IDictionary<string, IOpenApiSchema>
    if (schema.Properties != null &&
        schema.Properties.TryGetValue("id", out IOpenApiSchema? idPropI))
    {
      OpenApiSchema idProp = ResolveSchema(idPropI);
      if (!idProp.ReadOnly)
      {
        idProp.ReadOnly = true;
        count++;
      }
    }

    // Also check allOf schemas
    if (schema.AllOf != null)
    {
      foreach (var item in schema.AllOf)
      {
        // In 3.x, AllOf contains IOpenApiSchema; resolve to concrete
        OpenApiSchema allOfSchema = ResolveSchema(item);
        if (allOfSchema.Properties != null &&
            allOfSchema.Properties.TryGetValue("id", out IOpenApiSchema? allOfIdPropI))
        {
          OpenApiSchema allOfIdProp = ResolveSchema(allOfIdPropI);
          if (!allOfIdProp.ReadOnly)
          {
            allOfIdProp.ReadOnly = true;
            count++;
          }
        }
      }
    }

    return count;
  }
}
