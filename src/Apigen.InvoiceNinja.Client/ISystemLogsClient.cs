using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for system_logs operations
/// </summary>
public interface ISystemLogsClient
{
  /// <summary>
  /// Gets a list of system logs
  /// Operation: GET /api/v1/system_logs
  /// </summary>
  Task<ApiResponse<SystemLog[]>> ListAsync(GetSystemLogsRequest? request = null);

  /// <summary>
  /// Shows a system_logs
  /// Operation: GET /api/v1/system_logs/{id}
  /// </summary>
  Task<ApiResponse<SystemLog>> GetAsync(string id, ShowSystemLogsRequest? request = null);

}
