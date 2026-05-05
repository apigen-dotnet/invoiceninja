using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for Add product document
/// Operation: POST /api/v1/products/{id}/upload
/// </summary>
public partial class UploadProductRequest : BaseRequest
{
  /// <summary>
  /// Include child relationships of the Client Object. ie ?include=documents,system_logs
  /// 
  /// ```html
  /// Available includes:
  /// 
  /// contacts [All contacts related to the client]
  /// documents [All documents related to the client]
  /// gateway_tokens [All payment tokens related to the client]
  /// activities [All activities related to the client]
  /// ledger [The client ledger]
  /// system_logs [System logs related to the client]
  /// group_settings [The group settings object the client is assigned to]
  /// 
  /// ```
  /// 
  /// Usage:
  /// 
  /// ```html
  /// /api/v1/clients?include=contacts,documents,activities
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("include")]
  public string? Include { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    queryParams["_method"] = "POST";

    // Fixed parameters added for POST /api/v1/products/{id}/upload
    if (Include != null)
      queryParams["include"] = Include;

    return queryParams.ToQueryString();
  }
}
