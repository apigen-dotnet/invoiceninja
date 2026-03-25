using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for settings operations
/// </summary>
public interface ISettingsClient
{
  /// <summary>
  /// List passkeys
  /// Operation: GET /api/v1/settings/passkeys
  /// </summary>
  Task GetSettingsPasskeysAsync();

  /// <summary>
  /// Create passkey
  /// Operation: POST /api/v1/settings/passkeys
  /// </summary>
  Task PostSettingsPasskeysAsync(Apigen.InvoiceNinja.Models.PostSettingsPasskeysRequest postSettingsPasskeysRequest);

  /// <summary>
  /// Passkey registration options
  /// Operation: POST /api/v1/settings/passkeys/options
  /// </summary>
  Task PostSettingsPasskeysOptionsAsync();

  /// <summary>
  /// Delete passkey
  /// Operation: DELETE /api/v1/settings/passkeys/{passkey}
  /// </summary>
  Task DeleteAsync(string passkey);

}
