using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for Create payment
/// Operation: POST /api/v1/payments
/// </summary>
public partial class StorePaymentRequest : BaseRequest
{
  /// <summary>
  /// Includes child relationships in the response, format is comma separated. Check each model for the list of associated includes
  /// </summary>
  [JsonPropertyName("include")]
  public string? Include { get; set; }

  /// <summary>
  /// If true, the payment will be emailed to the client. If false, no email will be sent. This will override any other email settings for payments.
  /// 
  /// </summary>
  [JsonPropertyName("email_receipt")]
  public bool? EmailReceipt { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    queryParams["_method"] = "POST";

    // Fixed parameters added for POST /api/v1/payments
    if (Include != null)
      queryParams["include"] = Include;
    if (EmailReceipt != null)
      queryParams["email_receipt"] = EmailReceipt;

    return queryParams.ToQueryString();
  }
}
