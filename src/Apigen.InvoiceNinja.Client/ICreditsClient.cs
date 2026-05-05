using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for credits operations
/// </summary>
public partial interface ICreditsClient
{
  /// <summary>
  /// List credits
  /// Operation: GET /api/v1/credits
  /// </summary>
  Task<ApiResponse<Credit[]>> ListAsync(GetCreditsRequest? request = null);

  /// <summary>
  /// Create credit
  /// Operation: POST /api/v1/credits
  /// </summary>
  Task<ApiResponse<Credit>> CreateAsync(Apigen.InvoiceNinja.Models.CreditRequest creditRequest, StoreCreditRequest? request = null);

  /// <summary>
  /// Show credit
  /// Operation: GET /api/v1/credits/{id}
  /// </summary>
  Task<ApiResponse<Credit>> GetAsync(string id, ShowCreditRequest? request = null);

  /// <summary>
  /// Delete credit
  /// Operation: DELETE /api/v1/credits/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteCreditRequest? request = null);

  /// <summary>
  /// Edit credit
  /// Operation: GET /api/v1/credits/{id}/edit
  /// </summary>
  Task<ApiResponse<Invoice>> EditCreditAsync(string id, EditCreditRequest? request = null);

  /// <summary>
  /// Blank credit
  /// Operation: GET /api/v1/credits/create
  /// </summary>
  Task<ApiResponse<Credit>> GetCreditsCreateAsync(GetCreditsCreateRequest? request = null);

  /// <summary>
  /// Bulk credit actions
  /// Operation: POST /api/v1/credits/bulk
  /// </summary>
  Task BulkAsync(BulkCreditsRequest? request = null);

  /// <summary>
  /// Upload a credit document
  /// Operation: POST /api/v1/credits/{id}/upload
  /// </summary>
  Task<ApiResponse<Credit>> UploadCreditsAsync(string id, Apigen.InvoiceNinja.Models.UploadCreditsRequest uploadCreditsRequest, UploadCreditsRequest? request = null);

}
