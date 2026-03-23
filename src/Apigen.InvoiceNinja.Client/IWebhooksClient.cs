using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for webhooks operations
/// </summary>
public interface IWebhooksClient
{
  /// <summary>
  /// Gets a list of Webhooks
  /// Operation: GET /api/v1/webhooks
  /// </summary>
  Task<ApiResponse<Webhook[]>> ListAsync(GetWebhooksRequest? request = null);

  /// <summary>
  /// Adds a Webhook
  /// Operation: POST /api/v1/webhooks
  /// </summary>
  Task<ApiResponse<Webhook>> CreateAsync(StoreWebhookRequest? request = null);

  /// <summary>
  /// Shows a Webhook
  /// Operation: GET /api/v1/webhooks/{id}
  /// </summary>
  Task<ApiResponse<Webhook>> GetAsync(string id, ShowWebhookRequest? request = null);

  /// <summary>
  /// Updates a Webhook
  /// Operation: PUT /api/v1/webhooks/{id}
  /// </summary>
  Task<ApiResponse<Webhook>> UpdateAsync(string id, UpdateWebhookRequest? request = null);

  /// <summary>
  /// Shows a Webhook for editting
  /// Operation: GET /api/v1/webhooks/{id}/edit
  /// </summary>
  Task<ApiResponse<Webhook>> EditWebhookAsync(string id, EditWebhookRequest? request = null);

  /// <summary>
  /// Gets a new blank Webhook object
  /// Operation: GET /api/v1/webhooks/create
  /// </summary>
  Task<ApiResponse<Webhook>> GetWebhooksCreateAsync(GetWebhooksCreateRequest? request = null);

  /// <summary>
  /// Performs bulk actions on an array of Webhooks
  /// Operation: POST /api/v1/webhooks/bulk
  /// </summary>
  Task<ApiResponse<Webhook>> BulkAsync(Apigen.InvoiceNinja.Models.BulkWebhooksRequest bulkWebhooksRequest, BulkWebhooksRequest? request = null);

}
