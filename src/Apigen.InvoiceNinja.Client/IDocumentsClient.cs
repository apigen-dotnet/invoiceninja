using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for documents operations
/// </summary>
public partial interface IDocumentsClient
{
  /// <summary>
  /// Gets a list of documents
  /// Operation: GET /api/v1/documents
  /// </summary>
  Task<ApiResponse<Document[]>> ListAsync(GetDocumentsRequest? request = null);

}
