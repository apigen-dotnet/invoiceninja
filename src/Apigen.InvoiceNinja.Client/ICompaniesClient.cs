using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for companies operations
/// </summary>
public partial interface ICompaniesClient
{
  /// <summary>
  /// Gets a list of companies
  /// Operation: GET /api/v1/companies
  /// </summary>
  Task<ApiResponse<Company[]>> ListAsync(GetCompaniesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Adds a company
  /// Operation: POST /api/v1/companies
  /// </summary>
  Task<ApiResponse<Company>> CreateAsync(StoreCompanyRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets a new blank company object
  /// Operation: GET /api/v1/companies/create
  /// </summary>
  Task<ApiResponse<Company>> GetCompaniesCreateAsync(GetCompaniesCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows an company
  /// Operation: GET /api/v1/companies/{id}
  /// </summary>
  Task<ApiResponse<Company>> GetAsync(string id, ShowCompanyRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates an company
  /// Operation: PUT /api/v1/companies/{id}
  /// </summary>
  Task<ApiResponse<Company>> UpdateAsync(string id, UpdateCompanyRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes a company
  /// Operation: DELETE /api/v1/companies/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteCompanyRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows an company for editting
  /// Operation: GET /api/v1/companies/{id}/edit
  /// </summary>
  Task<ApiResponse<Company>> EditCompanyAsync(string id, EditCompanyRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Uploads a document to a company
  /// Operation: POST /api/v1/companies/{id}/upload
  /// </summary>
  Task<ApiResponse<Company>> UploadCompaniesAsync(string id, Apigen.InvoiceNinja.Models.UploadCompaniesRequest uploadCompaniesRequest, UploadCompaniesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Sets the company as the default company.
  /// Operation: POST /api/v1/companies/{company}/default
  /// </summary>
  Task<ApiResponse<Company>> SetDefaultCompanyAsync(string company, SetDefaultCompanyRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Returns the current comapny
  /// Operation: POST /api/v1/companies/current
  /// </summary>
  Task<ApiResponse<Company>> ShowCurrentCompanyAsync(ShowCurrentCompanyRequest? request = null, CancellationToken cancellationToken = default);

}
