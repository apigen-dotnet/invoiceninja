using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for Returns a PDF for the given activity
/// Operation: GET /api/v1/activities/download_entity/{activity_id}
/// </summary>
public class GetActivityHistoricalEntityPdfRequest : BaseRequest
{
  /// <summary>
  /// Include child relations of the Activity object, format is comma separated. **Note** it is possible to chain multiple includes together, ie. include=account,token
  /// </summary>
  [JsonPropertyName("include")]
  public string? Include { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Include != null)
      queryParams["include"] = Include;

    return queryParams.ToQueryString();
  }
}
