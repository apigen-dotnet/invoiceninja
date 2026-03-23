using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for companies operations
/// </summary>
public interface ICompaniesClient
{
  /// <summary>
  /// Gets a list of companies
  /// Operation: GET /api/v1/companies
  /// </summary>
  Task<ApiResponse<Company[]>> ListAsync(GetCompaniesRequest? request = null);

  /// <summary>
  /// Adds a company
  /// Operation: POST /api/v1/companies
  /// </summary>
  Task<ApiResponse<Company>> CreateAsync(StoreCompanyRequest? request = null);

  /// <summary>
  /// Gets a new blank company object
  /// Operation: GET /api/v1/companies/create
  /// </summary>
  Task<ApiResponse<Company>> GetCompaniesCreateAsync(GetCompaniesCreateRequest? request = null);

  /// <summary>
  /// Shows an company
  /// Operation: GET /api/v1/companies/{id}
  /// </summary>
  Task<ApiResponse<Company>> GetAsync(string id, ShowCompanyRequest? request = null);

  /// <summary>
  /// Updates an company
  /// Operation: PUT /api/v1/companies/{id}
  /// </summary>
  Task<ApiResponse<Company>> UpdateAsync(string id, UpdateCompanyRequest? request = null);

  /// <summary>
  /// Deletes a company
  /// Operation: DELETE /api/v1/companies/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteCompanyRequest? request = null);

  /// <summary>
  /// Shows an company for editting
  /// Operation: GET /api/v1/companies/{id}/edit
  /// </summary>
  Task<ApiResponse<Company>> EditCompanyAsync(string id, EditCompanyRequest? request = null);

  /// <summary>
  /// Uploads a document to a company
  /// Operation: POST /api/v1/companies/{id}/upload
  /// </summary>
  Task<ApiResponse<Company>> UploadCompaniesAsync(string id, Apigen.InvoiceNinja.Models.UploadCompaniesRequest uploadCompaniesRequest, UploadCompaniesRequest? request = null);

  /// <summary>
  /// Sets the company as the default company.
  /// Operation: POST /api/v1/companies/{company}/default
  /// </summary>
  Task<ApiResponse<Company>> SetDefaultCompanyAsync(string company, SetDefaultCompanyRequest? request = null);

  /// <summary>
  /// Returns the current comapny
  /// Operation: POST /api/v1/companies/current
  /// </summary>
  Task<ApiResponse<Company>> ShowCurrentCompanyAsync(ShowCurrentCompanyRequest? request = null);

}
