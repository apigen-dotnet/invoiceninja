using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for List locations
/// Operation: GET /api/v1/locations
/// </summary>
public class GetLocationsRequest : BaseRequest
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

  /// <summary>
  /// Filter by location name
  /// 
  /// ```html
  /// ?name=warehouse
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("name")]
  public string? Name { get; set; }

  /// <summary>
  /// Returns the list sorted by column in ascending or descending order.
  /// 
  /// ```html
  ///   ?sort=name|desc
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("sort")]
  public string? Sort { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Index != null)
      queryParams["index"] = Index;
    if (PerPage != null)
      queryParams["per_page"] = PerPage;
    if (Page != null)
      queryParams["page"] = Page;
    if (Name != null)
      queryParams["name"] = Name;
    if (Sort != null)
      queryParams["sort"] = Sort;

    return queryParams.ToQueryString();
  }
}
