using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for Pre Import checks - returns a reference to the job and the headers of the CSV
/// Operation: POST /api/v1/preimport
/// </summary>
public class PreimportRequest : BaseRequest
{
  /// <summary>
  /// Includes child relationships in the response, format is comma separated. Check each model for the list of associated includes
  /// </summary>
  [JsonPropertyName("include")]
  public string? Include { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    queryParams["_method"] = "POST";

    // Fixed parameters added for POST /api/v1/preimport
    if (Include != null)
      queryParams["include"] = Include;

    return queryParams.ToQueryString();
  }
}
