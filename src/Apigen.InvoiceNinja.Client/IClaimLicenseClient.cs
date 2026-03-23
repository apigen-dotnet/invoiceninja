using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for claim_license operations
/// </summary>
public interface IClaimLicenseClient
{
  /// <summary>
  /// Attempts to claim a white label license
  /// Operation: GET /api/v1/claim_license
  /// </summary>
  Task ListAsync(GetClaimLicenseRequest? request = null);

}
