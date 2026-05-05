using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for List payments
/// Operation: GET /api/v1/payments
/// </summary>
public partial class GetPaymentsRequest : BaseRequest
{
  /// <summary>
  /// Includes child relationships in the response, format is comma separated. Check each model for the list of associated includes
  /// </summary>
  [JsonPropertyName("include")]
  public string? Include { get; set; }

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
  /// Filter the entity based on their status. ie active / archived / deleted. Format is a comma separated string with any of the following options:  
  /// - active
  /// - archived
  /// - deleted  
  /// 
  /// ```html
  /// GET /api/v1/invoices?status=archived,deleted
  /// Returns only archived and deleted invoices
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("status")]
  public string? Status { get; set; }

  /// <summary>
  /// Filters the entity list by client_id. Suitable when you only want the entities of a specific client.
  /// 
  /// ```html
  /// GET /api/v1/invoices?client_id=AxB7Hjk9
  /// Returns only invoices for the specified client
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("client_id")]
  public string? ClientId { get; set; }

  /// <summary>
  /// Filters the entity list by the created at timestamp. Parameter value can be a datetime string or unix timestamp
  /// 
  /// ```html
  /// GET /api/v1/invoices?created_at=2022-01-10
  /// Returns entities created on January 10th, 2022
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("created_at")]
  public int? CreatedAt { get; set; }

  /// <summary>
  /// Filters the entity list by the updated at timestamp. Parameter value can be a datetime string or unix timestamp
  /// 
  /// ```html
  /// GET /api/v1/invoices?updated_at=2022-01-10
  /// Returns entities last updated on January 10th, 2022
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("updated_at")]
  public int? UpdatedAt { get; set; }

  /// <summary>
  /// Filters the entity list by entities that have been deleted.
  /// 
  /// ```html
  /// GET /api/v1/invoices?is_deleted=true
  /// Returns only soft-deleted entities
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("is_deleted")]
  public bool? IsDeleted { get; set; }

  /// <summary>
  /// Filters the entity list and only returns entities for clients that have not been deleted
  /// 
  /// ```html
  /// GET /api/v1/invoices?filter_deleted_clients=true
  /// Returns only invoices for active (non-deleted) clients
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("filter_deleted_clients")]
  public string? FilterDeletedClients { get; set; }

  /// <summary>
  /// Filters the entity list by an associated vendor
  /// 
  /// ```html
  /// GET /api/v1/purchases?vendor_id=AxB7Hjk9
  /// Returns only purchases for the specified vendor
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("vendor_id")]
  public string? VendorId { get; set; }

  /// <summary>
  /// Searches across a range of columns including:  
  /// - amount  
  /// - date  
  /// - custom_value1  
  /// - custom_value2  
  /// - custom_value3  
  /// - custom_value4
  /// 
  /// </summary>
  [JsonPropertyName("filter")]
  public string? Filter { get; set; }

  /// <summary>
  /// Search payments by payment number 
  /// 
  /// </summary>
  [JsonPropertyName("number")]
  public string? Number { get; set; }

  /// <summary>
  /// Returns the list sorted by column in ascending or descending order.
  /// </summary>
  [JsonPropertyName("sort")]
  public string? Sort { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Include != null)
      queryParams["include"] = Include;
    if (Index != null)
      queryParams["index"] = Index;
    if (PerPage != null)
      queryParams["per_page"] = PerPage;
    if (Page != null)
      queryParams["page"] = Page;
    if (Status != null)
      queryParams["status"] = Status;
    if (ClientId != null)
      queryParams["client_id"] = ClientId;
    if (CreatedAt != null)
      queryParams["created_at"] = CreatedAt;
    if (UpdatedAt != null)
      queryParams["updated_at"] = UpdatedAt;
    if (IsDeleted != null)
      queryParams["is_deleted"] = IsDeleted;
    if (FilterDeletedClients != null)
      queryParams["filter_deleted_clients"] = FilterDeletedClients;
    if (VendorId != null)
      queryParams["vendor_id"] = VendorId;
    if (Filter != null)
      queryParams["filter"] = Filter;
    if (Number != null)
      queryParams["number"] = Number;
    if (Sort != null)
      queryParams["sort"] = Sort;

    return queryParams.ToQueryString();
  }
}
