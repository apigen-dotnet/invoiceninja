using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for settings operations
/// </summary>
public partial interface ISettingsClient
{
  /// <summary>
  /// List passkeys
  /// Operation: GET /api/v1/settings/passkeys
  /// </summary>
  Task GetSettingsPasskeysAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Create passkey
  /// Operation: POST /api/v1/settings/passkeys
  /// </summary>
  Task PostSettingsPasskeysAsync(Apigen.InvoiceNinja.Models.PostSettingsPasskeysRequest postSettingsPasskeysRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Passkey registration options
  /// Operation: POST /api/v1/settings/passkeys/options
  /// </summary>
  Task PostSettingsPasskeysOptionsAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete passkey
  /// Operation: DELETE /api/v1/settings/passkeys/{passkey}
  /// </summary>
  Task DeleteAsync(string passkey, CancellationToken cancellationToken = default);

}
