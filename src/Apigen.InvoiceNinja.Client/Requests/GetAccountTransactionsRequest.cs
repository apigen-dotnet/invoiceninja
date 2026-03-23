using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for Retrieve transactions for a account
/// Operation: POST /api/v1/bank_integrations/get_transactions/account_id
/// </summary>
public class GetAccountTransactionsRequest : BaseRequest
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

    // Fixed parameters added for POST /api/v1/bank_integrations/get_transactions/account_id
    if (Include != null)
      queryParams["include"] = Include;

    return queryParams.ToQueryString();
  }
}
