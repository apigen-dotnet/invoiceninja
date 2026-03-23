using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for List credits
/// Operation: GET /api/v1/credits
/// </summary>
public class GetCreditsRequest : BaseRequest
{
  /// <summary>
  /// Includes child relationships in the response, format is comma separated. Check each model for the list of associated includes
  /// </summary>
  [JsonPropertyName("include")]
  public string? Include { get; set; }

  /// <summary>
  /// The number of records to return for each request, default is 20
  /// </summary>
  [JsonPropertyName("per_page")]
  public int? PerPage { get; set; }

  /// <summary>
  /// The page number to return for this request (when performing pagination), default is 1
  /// </summary>
  [JsonPropertyName("page")]
  public int? Page { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Include != null)
      queryParams["include"] = Include;
    if (PerPage != null)
      queryParams["per_page"] = PerPage;
    if (Page != null)
      queryParams["page"] = Page;

    return queryParams.ToQueryString();
  }
}
