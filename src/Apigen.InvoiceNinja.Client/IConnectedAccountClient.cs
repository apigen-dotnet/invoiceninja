using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for connected_account operations
/// </summary>
public partial interface IConnectedAccountClient
{
  /// <summary>
  /// Connect an oauth user to an existing user
  /// Operation: POST /api/v1/connected_account
  /// </summary>
  Task<ApiResponse<User>> CreateAsync(PostConnectedAccountRequest? request = null);

}
