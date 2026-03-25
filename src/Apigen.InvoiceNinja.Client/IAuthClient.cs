using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for auth operations
/// </summary>
public interface IAuthClient
{
  /// <summary>
  /// Passkey login options
  /// Operation: POST /api/v1/passkeys/login/options
  /// </summary>
  Task PostPasskeyLoginOptionsAsync(Apigen.InvoiceNinja.Models.PostPasskeyLoginOptionsRequest postPasskeyLoginOptionsRequest);

  /// <summary>
  /// Login
  /// Operation: POST /api/v1/login
  /// </summary>
  Task<ApiResponse<CompanyUser[]>> loginAsync(Apigen.InvoiceNinja.Models.PostLoginRequest postLoginRequest, LoginRequest? request = null);

}
