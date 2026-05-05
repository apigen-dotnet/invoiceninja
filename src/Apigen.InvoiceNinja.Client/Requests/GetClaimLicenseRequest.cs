using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for Attempts to claim a white label license
/// Operation: GET /api/v1/claim_license
/// </summary>
public partial class GetClaimLicenseRequest : BaseRequest
{
  /// <summary>
  /// The license hash
  /// </summary>
  [JsonPropertyName("license_key")]
  public string? LicenseKey { get; set; }

  /// <summary>
  /// The ID of the product purchased.
  /// </summary>
  [JsonPropertyName("product_id")]
  public string? ProductId { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (LicenseKey != null)
      queryParams["license_key"] = LicenseKey;
    if (ProductId != null)
      queryParams["product_id"] = ProductId;

    return queryParams.ToQueryString();
  }
}
