using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for refresh operations
/// </summary>
public interface IRefreshClient
{
  /// <summary>
  /// Refresh data by timestamp
  /// Operation: POST /api/v1/refresh
  /// </summary>
  Task<ApiResponse<CompanyUser>> CreateAsync(PostRefreshRequest? request = null);

}
