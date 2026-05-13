using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for recurring_quotes operations
/// </summary>
public partial interface IRecurringQuotesClient
{
  /// <summary>
  /// Gets a list of recurring_quotes
  /// Operation: GET /api/v1/recurring_quotes
  /// </summary>
  Task<ApiResponse<RecurringQuote[]>> ListAsync(GetRecurringQuotesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Adds a RecurringQuote
  /// Operation: POST /api/v1/recurring_quotes
  /// </summary>
  Task<ApiResponse<RecurringQuote>> CreateAsync(StoreRecurringQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets a new blank RecurringQuote object
  /// Operation: GET /api/v1/recurring_quotes/create
  /// </summary>
  Task<ApiResponse<RecurringQuote>> GetRecurringQuotesCreateAsync(GetRecurringQuotesCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows an RecurringQuote
  /// Operation: GET /api/v1/recurring_quotes/{id}
  /// </summary>
  Task<ApiResponse<RecurringQuote>> GetAsync(string id, ShowRecurringQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates an RecurringQuote
  /// Operation: PUT /api/v1/recurring_quotes/{id}
  /// </summary>
  Task<ApiResponse<RecurringQuote>> UpdateAsync(string id, UpdateRecurringQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes a RecurringQuote
  /// Operation: DELETE /api/v1/recurring_quotes/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteRecurringQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows an RecurringQuote for editting
  /// Operation: GET /api/v1/recurring_quotes/{id}/edit
  /// </summary>
  Task<ApiResponse<RecurringQuote>> EditRecurringQuoteAsync(string id, EditRecurringQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Performs bulk actions on an array of recurring_quotes
  /// Operation: POST /api/v1/recurring_quotes/bulk
  /// </summary>
  Task<ApiResponse<RecurringQuote>> BulkAsync(BulkRecurringQuotesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Performs a custom action on an RecurringQuote
  /// Operation: GET /api/v1/recurring_quotes/{id}/{action}
  /// </summary>
  Task<ApiResponse<RecurringQuote>> GetAsync(string id, string action, ActionRecurringQuoteRequest? request = null, CancellationToken cancellationToken = default);

}
