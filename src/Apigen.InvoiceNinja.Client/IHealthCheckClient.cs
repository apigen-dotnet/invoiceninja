using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for health_check operations
/// </summary>
public interface IHealthCheckClient
{
  /// <summary>
  /// Attempts to get a health check from the API
  /// Operation: GET /api/v1/health_check
  /// </summary>
  Task ListAsync();

}
