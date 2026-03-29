using Microsoft.OpenApi.Models;
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
    foreach (var schema in document.Components.Schemas.Values)
    {
      count += PatchSchema(schema);
    }

    return count > 0;
  }

  private static int PatchSchema(OpenApiSchema schema)
  {
    int count = 0;

    if (schema.Properties != null &&
        schema.Properties.TryGetValue("id", out OpenApiSchema? idProp) &&
        !idProp.ReadOnly)
    {
      idProp.ReadOnly = true;
      count++;
    }

    // Also check allOf schemas
    if (schema.AllOf != null)
    {
      foreach (var item in schema.AllOf)
      {
        if (item.Properties != null &&
            item.Properties.TryGetValue("id", out OpenApiSchema? allOfIdProp) &&
            !allOfIdProp.ReadOnly)
        {
          allOfIdProp.ReadOnly = true;
          count++;
        }
      }
    }

    return count;
  }
}
