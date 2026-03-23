using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for client_gateway_tokens operations
/// </summary>
public interface IClientGatewayTokensClient
{
  /// <summary>
  /// List of client payment tokens
  /// Operation: GET /api/v1/client_gateway_tokens
  /// </summary>
  Task<ApiResponse<ClientGatewayToken[]>> ListAsync(GetClientGatewayTokensRequest? request = null);

  /// <summary>
  /// Adds a client payment token
  /// Operation: POST /api/v1/client_gateway_tokens
  /// </summary>
  Task<ApiResponse<ClientGatewayToken>> CreateAsync(StoreClientGatewayTokenRequest? request = null);

  /// <summary>
  /// Shows a client payment token
  /// Operation: GET /api/v1/client_gateway_tokens/{id}
  /// </summary>
  Task<ApiResponse<ClientGatewayToken>> GetAsync(string id, ShowClientGatewayTokenRequest? request = null);

  /// <summary>
  /// Updates a client payment token
  /// Operation: PUT /api/v1/client_gateway_tokens/{id}
  /// </summary>
  Task<ApiResponse<ClientGatewayToken>> UpdateAsync(string id, UpdateClientGatewayTokenRequest? request = null);

  /// <summary>
  /// Deletes a client
  /// Operation: DELETE /api/v1/client_gateway_tokens/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteClientGatewayTokenRequest? request = null);

  /// <summary>
  /// Shows a client payment token for editting
  /// Operation: GET /api/v1/client_gateway_tokens/{id}/edit
  /// </summary>
  Task<ApiResponse<ClientGatewayToken>> EditClientGatewayTokenAsync(string id, EditClientGatewayTokenRequest? request = null);

  /// <summary>
  /// Gets a new blank client payment token object
  /// Operation: GET /api/v1/client_gateway_tokens/create
  /// </summary>
  Task<ApiResponse<ClientGatewayToken>> GetClientGatewayTokensCreateAsync(GetClientGatewayTokensCreateRequest? request = null);

}
