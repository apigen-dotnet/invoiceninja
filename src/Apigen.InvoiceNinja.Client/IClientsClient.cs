using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for clients operations
/// </summary>
public interface IClientsClient
{
  /// <summary>
  /// List clients
  /// 
  /// Operation: GET /api/v1/clients
  /// </summary>
  Task<ApiResponse<Apigen.InvoiceNinja.Models.Client[]>> ListAsync(GetClientsRequest? request = null);

  /// <summary>
  /// Create client
  /// Operation: POST /api/v1/clients
  /// </summary>
  Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> CreateAsync(Apigen.InvoiceNinja.Models.ClientRequest clientRequest, StoreClientRequest? request = null);

  /// <summary>
  /// Show client
  /// Operation: GET /api/v1/clients/{id}
  /// </summary>
  Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> GetAsync(string id, ShowClientRequest? request = null);

  /// <summary>
  /// Update client
  /// Operation: PUT /api/v1/clients/{id}
  /// </summary>
  Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> UpdateAsync(string id, Apigen.InvoiceNinja.Models.ClientRequest clientRequest, UpdateClientRequest? request = null);

  /// <summary>
  /// Delete client
  /// Operation: DELETE /api/v1/clients/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteClientRequest? request = null);

  /// <summary>
  /// Edit Client
  /// Operation: GET /api/v1/clients/{id}/edit
  /// </summary>
  Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> EditClientAsync(string id, EditClientRequest? request = null);

  /// <summary>
  /// Blank Client
  /// Operation: GET /api/v1/clients/create
  /// </summary>
  Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> GetClientsCreateAsync(GetClientsCreateRequest? request = null);

  /// <summary>
  /// Bulk client actions
  /// Operation: POST /api/v1/clients/bulk
  /// </summary>
  Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> BulkAsync(Apigen.InvoiceNinja.Models.GenericBulkAction genericBulkAction, BulkClientsRequest? request = null);

  /// <summary>
  /// Add client document
  /// Operation: POST /api/v1/clients/{id}/upload
  /// </summary>
  Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> UploadClientAsync(string id, Apigen.InvoiceNinja.Models.UploadClientRequest uploadClientRequest, UploadClientRequest? request = null);

  /// <summary>
  /// Purge client
  /// Operation: POST /api/v1/clients/{id}/purge
  /// </summary>
  Task PurgeClientAsync(string id);

  /// <summary>
  /// Merge client
  /// Operation: POST /api/v1/clients/{id}/{mergeable_client_hashed_id}/merge
  /// </summary>
  Task MergeClientAsync(string id, string mergeableClientHashedId, MergeClientRequest? request = null);

  /// <summary>
  /// Client statement PDF
  /// Operation: POST /api/v1/client_statement
  /// </summary>
  Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> ClientStatementAsync(Apigen.InvoiceNinja.Models.ClientStatementRequest clientStatementRequest, ClientStatementRequest? request = null);

  /// <summary>
  /// Removes email suppression of a user in the system
  /// Operation: POST /api/v1/reactivate_email/{bounce_id}
  /// </summary>
  Task ReactivateEmailAsync(string bounceId, ReactivateEmailRequest? request = null);

  /// <summary>
  /// Update tax data
  /// Operation: POST /api/v1/clients/{client}/updateTaxData
  /// </summary>
  Task UpdateClientTaxDataAsync(string client, UpdateClientTaxDataRequest? request = null);

}
