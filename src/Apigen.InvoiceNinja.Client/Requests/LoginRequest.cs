using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for Login
/// Operation: POST /api/v1/login
/// </summary>
public partial class LoginRequest : BaseRequest
{
  /// <summary>
  /// Include child relations of the CompanyUser object, format is comma separated.    
  /// 
  /// &lt;br /&gt;
  /// 
  /// &gt; ### **Note**: it is possible to chain multiple includes together, ie. include=account,token
  /// 
  /// &lt;br /&gt;
  /// 
  /// ```html
  /// 
  /// Available includes:
  /// 
  ///   user
  ///   company
  ///   token
  ///   account
  /// ```
  /// 
  /// </summary>
  [JsonPropertyName("include")]
  public string? Include { get; set; }

  /// <summary>
  /// This include will return the full set of static variables used in the application including:
  ///   - Currencies
  ///   - Countries 
  ///   - Languages
  ///   - Payment Types
  ///   - Email Templatees
  ///   - Industries
  /// 
  /// </summary>
  [JsonPropertyName("include_static")]
  public string? IncludeStatic { get; set; }

  /// <summary>
  /// Clears cache
  /// 
  /// Clears (and rebuilds) the static variable cache.  
  /// 
  /// </summary>
  [JsonPropertyName("clear_cache")]
  public string? ClearCache { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    queryParams["_method"] = "POST";

    // Fixed parameters added for POST /api/v1/login
    if (Include != null)
      queryParams["include"] = Include;
    if (IncludeStatic != null)
      queryParams["include_static"] = IncludeStatic;
    if (ClearCache != null)
      queryParams["clear_cache"] = ClearCache;

    return queryParams.ToQueryString();
  }
}
