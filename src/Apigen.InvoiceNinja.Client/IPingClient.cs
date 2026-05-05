using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for ping operations
/// </summary>
public partial interface IPingClient
{
  /// <summary>
  /// Attempts to ping the API
  /// Operation: GET /api/v1/ping
  /// </summary>
  Task ListAsync();

  /// <summary>
  /// Returns the last error
  /// Operation: GET /api/v1/last_error
  /// </summary>
  Task GetLastErrorAsync();

}
