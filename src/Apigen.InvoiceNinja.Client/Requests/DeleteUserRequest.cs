using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for Deletes a User
/// Operation: DELETE /api/v1/users/{id}
/// </summary>
public class DeleteUserRequest : BaseRequest
{
  /// <summary>
  /// Includes child relationships in the response, format is comma separated. Check each model for the list of associated includes
  /// </summary>
  [JsonPropertyName("include")]
  public string? Include { get; set; }

  /// <summary>
  /// Customized name for the Users API Token
  /// </summary>
  [JsonPropertyName("token_name")]
  public string? TokenName { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Include != null)
      queryParams["include"] = Include;
    if (TokenName != null)
      queryParams["token_name"] = TokenName;

    return queryParams.ToQueryString();
  }
}
