using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for tokens operations
/// </summary>
public interface ITokensClient
{
  /// <summary>
  /// Gets a list of company tokens
  /// Operation: GET /api/v1/tokens
  /// </summary>
  Task<ApiResponse<CompanyToken[]>> ListAsync(GetTokensRequest? request = null);

  /// <summary>
  /// Adds a token
  /// Operation: POST /api/v1/tokens
  /// </summary>
  Task<ApiResponse<CompanyToken>> CreateAsync(StoreTokenRequest? request = null);

  /// <summary>
  /// Shows a token
  /// Operation: GET /api/v1/tokens/{id}
  /// </summary>
  Task<ApiResponse<CompanyToken>> GetAsync(string id, ShowTokenRequest? request = null);

  /// <summary>
  /// Updates a token
  /// Operation: PUT /api/v1/tokens/{id}
  /// </summary>
  Task<ApiResponse<CompanyToken>> UpdateAsync(string id, UpdateTokenRequest? request = null);

  /// <summary>
  /// Deletes a token
  /// Operation: DELETE /api/v1/tokens/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteTokenRequest? request = null);

  /// <summary>
  /// Shows a token for editting
  /// Operation: GET /api/v1/tokens/{id}/edit
  /// </summary>
  Task<ApiResponse<CompanyToken>> EditTokenAsync(string id, EditTokenRequest? request = null);

  /// <summary>
  /// Gets a new blank token object
  /// Operation: GET /api/v1/tokens/create
  /// </summary>
  Task<ApiResponse<CompanyToken>> GetTokensCreateAsync(GetTokensCreateRequest? request = null);

  /// <summary>
  /// Performs bulk actions on an array of tokens
  /// Operation: POST /api/v1/tokens/bulk
  /// </summary>
  Task<ApiResponse<CompanyToken>> BulkAsync(BulkTokensRequest? request = null);

}
