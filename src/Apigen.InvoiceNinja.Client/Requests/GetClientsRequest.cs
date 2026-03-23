using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for List clients

/// Operation: GET /api/v1/clients
/// </summary>
public class GetClientsRequest : BaseRequest
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
  /// Filter by client name  
  /// 
  /// ```html
  /// ?name=bob
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("name")]
  public string? Name { get; set; }

  /// <summary>
  /// Filter by client balance, format uses an operator and value separated by a colon. lt,lte, gt, gte, eq
  /// 
  /// ```html
  /// ?balance=lt:10
  /// ```
  /// 
  /// ie all clients whose balance is less than 10
  /// 
  /// </summary>
  [JsonPropertyName("balance")]
  public string? Balance { get; set; }

  /// <summary>
  /// Filter between client balances, format uses two values separated by a colon
  /// 
  /// ```html
  /// ?between_balance=10:100
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("between_balance")]
  public string? BetweenBalance { get; set; }

  /// <summary>
  /// Filter by client email
  /// 
  /// ```html
  /// ?email=bob@gmail.com
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("email")]
  public string? Email { get; set; }

  /// <summary>
  /// Filter by client id_number
  /// 
  /// ```html
  /// ?id_number=0001
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("id_number")]
  public string? IdNumber { get; set; }

  /// <summary>
  /// Filter by client number
  /// 
  /// ```html
  /// ?number=0002
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("number")]
  public string? Number { get; set; }

  /// <summary>
  /// Broad filter which targets multiple client columns:
  /// 
  ///   ```html
  ///     name, 
  ///     id_number, 
  ///     contact.first_name 
  ///     contact.last_name, 
  ///     contact.email, 
  ///     contact.phone
  ///     custom_value1,
  ///     custom_value2,
  ///     custom_value3,
  ///     custom_value4,
  ///   ```
  /// 
  ///   ```html
  ///   ?filter=Bobby
  ///   ```
  /// 
  /// </summary>
  [JsonPropertyName("filter")]
  public string? Filter { get; set; }

  /// <summary>
  /// Returns the list sorted by column in ascending or descending order.
  /// 
  /// Ensure you use column | direction, ie.
  /// 
  /// ```html
  ///   ?sort=id|desc
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("sort")]
  public string? Sort { get; set; }

  /// <summary>
  /// Returns the list of clients assigned to {group_id}
  /// 
  /// ```html
  ///   ?group=X89sjd8
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("group")]
  public string? Group { get; set; }

  /// <summary>
  /// Returns the list of clients with {client_id} - proxy call to retrieve a client_id wrapped in an array
  /// 
  /// ```html
  ///   ?client_id=X89sjd8
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("client_id")]
  public string? ClientId { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Include != null)
      queryParams["include"] = Include;
    if (Index != null)
      queryParams["index"] = Index;
    if (Status != null)
      queryParams["status"] = Status;
    if (CreatedAt != null)
      queryParams["created_at"] = CreatedAt;
    if (UpdatedAt != null)
      queryParams["updated_at"] = UpdatedAt;
    if (IsDeleted != null)
      queryParams["is_deleted"] = IsDeleted;
    if (FilterDeletedClients != null)
      queryParams["filter_deleted_clients"] = FilterDeletedClients;
    if (PerPage != null)
      queryParams["per_page"] = PerPage;
    if (Page != null)
      queryParams["page"] = Page;
    if (Name != null)
      queryParams["name"] = Name;
    if (Balance != null)
      queryParams["balance"] = Balance;
    if (BetweenBalance != null)
      queryParams["between_balance"] = BetweenBalance;
    if (Email != null)
      queryParams["email"] = Email;
    if (IdNumber != null)
      queryParams["id_number"] = IdNumber;
    if (Number != null)
      queryParams["number"] = Number;
    if (Filter != null)
      queryParams["filter"] = Filter;
    if (Sort != null)
      queryParams["sort"] = Sort;
    if (Group != null)
      queryParams["group"] = Group;
    if (ClientId != null)
      queryParams["client_id"] = ClientId;

    return queryParams.ToQueryString();
  }
}
