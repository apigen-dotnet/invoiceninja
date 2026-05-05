using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for logout operations
/// </summary>
public partial interface ILogoutClient
{
  /// <summary>
  /// Logs the user out of their current session
  /// Operation: POST /api/v1/logout
  /// </summary>
  Task CreateAsync(GetLogoutRequest? request = null);

}
