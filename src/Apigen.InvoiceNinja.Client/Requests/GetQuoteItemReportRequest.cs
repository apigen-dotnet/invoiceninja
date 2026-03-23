using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for Quote item reports
/// Operation: POST /api/v1/reports/quote_items
/// </summary>
public class GetQuoteItemReportRequest : BaseRequest
{
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

    queryParams["_method"] = "POST";

    // Fixed parameters added for POST /api/v1/reports/quote_items
    if (PerPage != null)
      queryParams["per_page"] = PerPage;
    if (Page != null)
      queryParams["page"] = Page;

    return queryParams.ToQueryString();
  }
}
