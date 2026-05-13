using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for quotes operations
/// </summary>
public partial interface IQuotesClient
{
  /// <summary>
  /// List quotes
  /// Operation: GET /api/v1/quotes
  /// </summary>
  Task<ApiResponse<Quote[]>> ListAsync(GetQuotesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create quote
  /// Operation: POST /api/v1/quotes
  /// </summary>
  Task<ApiResponse<Quote>> CreateAsync(Apigen.InvoiceNinja.Models.QuoteRequest quoteRequest, StoreQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Show quote
  /// Operation: GET /api/v1/quotes/{id}
  /// </summary>
  Task<ApiResponse<Quote>> GetAsync(string id, ShowQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update quote
  /// Operation: PUT /api/v1/quotes/{id}
  /// </summary>
  Task<ApiResponse<Quote>> UpdateAsync(string id, Apigen.InvoiceNinja.Models.QuoteRequest quoteRequest, UpdateQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete quote
  /// Operation: DELETE /api/v1/quotes/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Edit quote
  /// Operation: GET /api/v1/quotes/{id}/edit
  /// </summary>
  Task<ApiResponse<Quote>> EditQuoteAsync(string id, EditQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Blank quote
  /// Operation: GET /api/v1/quotes/create
  /// </summary>
  Task<ApiResponse<Quote>> GetQuotesCreateAsync(GetQuotesCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Bulk quote actions
  /// Operation: POST /api/v1/quotes/bulk
  /// </summary>
  Task<ApiResponse<Quote>> BulkAsync(Apigen.InvoiceNinja.Models.BulkQuotesRequest bulkQuotesRequest, BulkQuotesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Performs a custom action on an Quote
  /// Operation: GET /api/v1/quotes/{id}/{action}
  /// </summary>
  Task<ApiResponse<Quote>> GetAsync(string id, string action, ActionQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Download quote PDF
  /// Operation: GET /api/v1/quote/{invitation_key}/download
  /// </summary>
  Task<Stream> DownloadQuoteAsync(string invitationKey, DownloadQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Upload a quote document
  /// Operation: POST /api/v1/quotes/{id}/upload
  /// </summary>
  Task<ApiResponse<Quote>> UploadQuoteAsync(string id, Apigen.InvoiceNinja.Models.UploadQuoteRequest uploadQuoteRequest, UploadQuoteRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Download quote PDF
  /// Operation: GET /api/v1/credit/{invitation_key}/download
  /// </summary>
  Task<Stream> DownloadCreditAsync(string invitationKey, DownloadCreditRequest? request = null, CancellationToken cancellationToken = default);

}
