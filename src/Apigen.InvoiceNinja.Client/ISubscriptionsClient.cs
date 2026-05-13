using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for subscriptions operations
/// </summary>
public partial interface ISubscriptionsClient
{
  /// <summary>
  /// Gets a list of subscriptions
  /// Operation: GET /api/v1/subscriptions
  /// </summary>
  Task<ApiResponse<Subscription[]>> ListAsync(GetSubscriptionsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Adds a subscriptions
  /// Operation: POST /api/v1/subscriptions
  /// </summary>
  Task<ApiResponse<Subscription>> CreateAsync(StoreSubscriptionRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets a new blank subscriptions object
  /// Operation: GET /api/v1/subscriptions/create
  /// </summary>
  Task<ApiResponse<Subscription>> GetSubscriptionsCreateAsync(GetSubscriptionsCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows an subscriptions
  /// Operation: GET /api/v1/subscriptions/{id}
  /// </summary>
  Task<ApiResponse<Subscription>> GetAsync(string id, ShowSubscriptionRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates an subscriptions
  /// Operation: PUT /api/v1/subscriptions/{id}
  /// </summary>
  Task<ApiResponse<Subscription>> UpdateAsync(string id, UpdateSubscriptionRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes a subscriptions
  /// Operation: DELETE /api/v1/subscriptions/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteSubscriptionRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows an subscriptions for editting
  /// Operation: GET /api/v1/subscriptions/{id}/edit
  /// </summary>
  Task<ApiResponse<Subscription>> EditSubscriptionAsync(string id, EditSubscriptionRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Performs bulk actions on an array of subscriptions
  /// Operation: POST /api/v1/subscriptions/bulk
  /// </summary>
  Task<ApiResponse<Subscription>> BulkAsync(BulkSubscriptionsRequest? request = null, CancellationToken cancellationToken = default);

}
