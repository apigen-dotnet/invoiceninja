using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for update operations
/// </summary>
public interface IUpdateClient
{
  /// <summary>
  /// Performs a system update
  /// Operation: POST /api/v1/self-update
  /// </summary>
  Task SelfUpdateAsync(SelfUpdateRequest? request = null);

  /// <summary>
  /// Check for available update
  /// Operation: POST /api/v1/self-update/check_version
  /// </summary>
  Task SelfUpdateCheckVersionAsync();

}
