using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for List invoices
/// Operation: GET /api/v1/invoices
/// </summary>
public class GetInvoicesRequest : BaseRequest
{
  /// <summary>
  /// Includes child relationships in the response, format is comma separated. Check each model for the list of associated includes
  /// </summary>
  [JsonPropertyName("include")]
  public string? Include { get; set; }

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
  /// A comma separated list of invoice status strings. Valid options include:  
  /// - all
  /// - paid  
  /// - unpaid  
  /// - overdue   
  /// 
  /// </summary>
  [JsonPropertyName("client_status")]
  public string? ClientStatus { get; set; }

  /// <summary>
  /// Search invoices by invoice number 
  /// 
  /// </summary>
  [JsonPropertyName("number")]
  public string? Number { get; set; }

  /// <summary>
  /// Searches across a range of columns including:  
  /// - number  
  /// - po_number  
  /// - date  
  /// - amount  
  /// - balance  
  /// - custom_value1  
  /// - custom_value2  
  /// - custom_value3  
  /// - custom_value4
  /// - client.name
  /// - client.contacts.[first_name, last_name, email]
  /// - line_items.[product_key, notes]
  /// 
  /// </summary>
  [JsonPropertyName("filter")]
  public string? Filter { get; set; }

  /// <summary>
  /// Returns the invoice list without the invoices of deleted clients.
  /// 
  /// </summary>
  [JsonPropertyName("without_deleted_clients")]
  public string? WithoutDeletedClients { get; set; }

  /// <summary>
  /// Returns the list of invoices that are overdue
  /// 
  /// </summary>
  [JsonPropertyName("overdue")]
  public string? Overdue { get; set; }

  /// <summary>
  /// Returns the invoice list that are payable for a defined client. Please note, you must pass the client_id as the value for this query parameter
  /// 
  /// </summary>
  [JsonPropertyName("payable")]
  public string? Payable { get; set; }

  /// <summary>
  /// Returns the list sorted by column in ascending or descending order.
  /// </summary>
  [JsonPropertyName("sort")]
  public string? Sort { get; set; }

  /// <summary>
  /// Searches on the private_notes field of the invoices
  /// 
  /// </summary>
  [JsonPropertyName("private_notes")]
  public string? PrivateNotes { get; set; }

  /// <summary>
  /// Filters the invoices by invoice date returns a list of invoices after (and including) the date
  /// 
  /// </summary>
  [JsonPropertyName("date")]
  public string? Date { get; set; }

  /// <summary>
  /// Filters the invoices by invoice date returns a list of invoices between two dates
  /// 
  /// </summary>
  [JsonPropertyName("date_range")]
  public string? DateRange { get; set; }

  /// <summary>
  /// Filters the invoices by status id
  /// 
  /// ```html
  ///   STATUS_DRAFT = 1;
  ///   STATUS_SENT = 2;
  ///   STATUS_PARTIAL = 3;
  ///   STATUS_PAID = 4;
  ///   STATUS_CANCELLED = 5;
  ///   STATUS_REVERSED = 6;
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("status_id")]
  public int? StatusId { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Include != null)
      queryParams["include"] = Include;
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
    if (PerPage != null)
      queryParams["per_page"] = PerPage;
    if (Page != null)
      queryParams["page"] = Page;
    if (ClientStatus != null)
      queryParams["client_status"] = ClientStatus;
    if (Number != null)
      queryParams["number"] = Number;
    if (Filter != null)
      queryParams["filter"] = Filter;
    if (WithoutDeletedClients != null)
      queryParams["without_deleted_clients"] = WithoutDeletedClients;
    if (Overdue != null)
      queryParams["overdue"] = Overdue;
    if (Payable != null)
      queryParams["payable"] = Payable;
    if (Sort != null)
      queryParams["sort"] = Sort;
    if (PrivateNotes != null)
      queryParams["private_notes"] = PrivateNotes;
    if (Date != null)
      queryParams["date"] = Date;
    if (DateRange != null)
      queryParams["date_range"] = DateRange;
    if (StatusId != null)
      queryParams["status_id"] = StatusId;

    return queryParams.ToQueryString();
  }
}
