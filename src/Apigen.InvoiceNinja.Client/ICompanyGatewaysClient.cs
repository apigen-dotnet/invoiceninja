using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for company_gateways operations
/// </summary>
public interface ICompanyGatewaysClient
{
  /// <summary>
  /// Gets a list of company_gateways
  /// Operation: GET /api/v1/company_gateways
  /// </summary>
  Task<ApiResponse<CompanyGateway[]>> ListAsync(GetCompanyGatewaysRequest? request = null);

  /// <summary>
  /// Adds a CompanyGateway
  /// Operation: POST /api/v1/company_gateways
  /// </summary>
  Task<ApiResponse<CompanyGateway>> CreateAsync(StoreCompanyGatewayRequest? request = null);

  /// <summary>
  /// Gets a new blank CompanyGateway object
  /// Operation: GET /api/v1/company_gateways/create
  /// </summary>
  Task<ApiResponse<CompanyGateway>> GetCompanyGatewaysCreateAsync(GetCompanyGatewaysCreateRequest? request = null);

  /// <summary>
  /// Shows an CompanyGateway
  /// Operation: GET /api/v1/company_gateways/{id}
  /// </summary>
  Task<ApiResponse<CompanyGateway>> GetAsync(string id, ShowCompanyGatewayRequest? request = null);

  /// <summary>
  /// Updates an CompanyGateway
  /// Operation: PUT /api/v1/company_gateways/{id}
  /// </summary>
  Task<ApiResponse<CompanyGateway>> UpdateAsync(string id, UpdateCompanyGatewayRequest? request = null);

  /// <summary>
  /// Deletes a CompanyGateway
  /// Operation: DELETE /api/v1/company_gateways/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteCompanyGatewayRequest? request = null);

  /// <summary>
  /// Shows an CompanyGateway for editting
  /// Operation: GET /api/v1/company_gateways/{id}/edit
  /// </summary>
  Task<ApiResponse<CompanyGateway>> EditCompanyGatewayAsync(string id, EditCompanyGatewayRequest? request = null);

  /// <summary>
  /// Performs bulk actions on an array of company_gateways
  /// Operation: POST /api/v1/company_gateways/bulk
  /// </summary>
  Task<ApiResponse<CompanyGateway>> BulkAsync(BulkCompanyGatewaysRequest? request = null);

}
