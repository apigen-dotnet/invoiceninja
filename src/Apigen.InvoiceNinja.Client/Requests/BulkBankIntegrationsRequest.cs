using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for Performs bulk actions on an array of bank_integrations
/// Operation: POST /api/v1/bank_integrations/bulk
/// </summary>
public class BulkBankIntegrationsRequest : BaseRequest
{
  /// <summary>
  /// Replaces the default response index from data to a user specific string
  /// 
  /// ie.
  /// 
  /// ```html
  ///   ?index=new_index
  /// ```
  /// 
  /// response is wrapped
  /// 
  /// ```json
  ///   {
  ///     &apos;new_index&apos; : [
  ///       .....  
  ///     ]
  ///   }
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("index")]
  public string? Index { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    queryParams["_method"] = "POST";

    // Fixed parameters added for POST /api/v1/bank_integrations/bulk
    if (Index != null)
      queryParams["index"] = Index;

    return queryParams.ToQueryString();
  }
}
