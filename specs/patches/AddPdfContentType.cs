using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi;
using Apigen.Generator;

/// <summary>
/// Add application/pdf content type to download endpoints that are missing it.
/// Without this, the generator produces void methods that discard the PDF response body.
/// </summary>
public class AddPdfContentType : ISpecPatch
{
  public string Name => "Add application/pdf content to download endpoints";

  private static readonly List<(string Method, string Path)> Endpoints = new()
  {
    ("GET", "/api/v1/activities/download_entity/{activity_id}"),
    ("GET", "/api/v1/recurring_invoice/{invitation_key}/download"),
    ("GET", "/api/v1/invoice/{invitation_key}/download"),
    ("GET", "/api/v1/invoices/{id}/delivery_note"),
    ("GET", "/api/v1/quote/{invitation_key}/download"),
    ("GET", "/api/v1/credit/{invitation_key}/download"),
    ("GET", "/api/v1/purchase_order/{invitation_key}/download"),
  };

  public bool Apply(OpenApiDocument document)
  {
    if (document.Paths == null) return false;

    int count = 0;
    foreach (var (methodStr, path) in Endpoints)
    {
      if (!document.Paths.TryGetValue(path, out IOpenApiPathItem? iPathItem)) continue;
      if (iPathItem is not OpenApiPathItem pathItem) continue;
      if (pathItem.Operations == null) continue;

      var httpMethod = new System.Net.Http.HttpMethod(methodStr);
      if (!pathItem.Operations.TryGetValue(httpMethod, out OpenApiOperation? operation)) continue;
      if (operation.Responses == null) continue;

      var successResponse = operation.Responses.FirstOrDefault(r => r.Key.StartsWith("2"));
      if (successResponse.Value == null) continue;
      if (successResponse.Value is not OpenApiResponse response) continue;

      // Skip if already has content defined
      if (response.Content != null && response.Content.Count > 0) continue;

      response.Content = new Dictionary<string, IOpenApiMediaType>
      {
        ["application/pdf"] = new OpenApiMediaType
        {
          Schema = new OpenApiSchema
          {
            Type = JsonSchemaType.String,
            Format = "binary"
          }
        }
      };
      count++;
    }

    return count > 0;
  }
}
