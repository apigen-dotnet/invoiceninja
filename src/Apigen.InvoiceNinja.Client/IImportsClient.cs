using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for imports operations
/// </summary>
public interface IImportsClient
{
  /// <summary>
  /// Pre Import CSV data
  /// Operation: POST /api/v1/preimport
  /// </summary>
  Task<ApiResponse<JsonElement>> PreimportAsync(Apigen.InvoiceNinja.Models.PreImportRequest preImportRequest, PreimportRequest? request = null);

  /// <summary>
  /// Import CSV data
  /// Operation: POST /api/v1/import
  /// </summary>
  Task<ApiResponse<JsonElement>> PostAsync(Apigen.InvoiceNinja.Models.PostImportRequest postImportRequest, PostImportRequest? request = null);

}
