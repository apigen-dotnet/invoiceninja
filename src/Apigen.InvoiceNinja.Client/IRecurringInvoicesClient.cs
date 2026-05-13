using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for Recurring Invoices operations
/// </summary>
public partial interface IRecurringInvoicesClient
{
  /// <summary>
  /// List recurring invoices
  /// Operation: GET /api/v1/recurring_invoices
  /// </summary>
  Task<ApiResponse<RecurringInvoice[]>> GetRecurringInvoicesAsync(GetRecurringInvoicesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create recurring invoice
  /// Operation: POST /api/v1/recurring_invoices
  /// </summary>
  Task<ApiResponse<RecurringInvoice>> StoreRecurringInvoiceAsync(Apigen.InvoiceNinja.Models.RecurringInvoiceRequest recurringInvoiceRequest, StoreRecurringInvoiceRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Show recurring invoice
  /// Operation: GET /api/v1/recurring_invoices/{id}
  /// </summary>
  Task<ApiResponse<RecurringInvoice>> GetAsync(string id, ShowRecurringInvoiceRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update recurring invoice
  /// Operation: PUT /api/v1/recurring_invoices/{id}
  /// </summary>
  Task<ApiResponse<RecurringInvoice>> UpdateAsync(string id, UpdateRecurringInvoiceRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete recurring invoice
  /// Operation: DELETE /api/v1/recurring_invoices/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteRecurringInvoiceRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Edit recurring invoice
  /// Operation: GET /api/v1/recurring_invoices/{id}/edit
  /// </summary>
  Task<ApiResponse<RecurringInvoice>> EditRecurringInvoiceAsync(string id, EditRecurringInvoiceRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Blank recurring invoice
  /// Operation: GET /api/v1/recurring_invoices/create
  /// </summary>
  Task<ApiResponse<RecurringInvoice>> GetRecurringInvoicesCreateAsync(GetRecurringInvoicesCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Bulk recurring invoice actions
  /// Operation: POST /api/v1/recurring_invoices/bulk
  /// </summary>
  Task<ApiResponse<RecurringInvoice>> BulkAsync(Apigen.InvoiceNinja.Models.BulkRecurringInvoicesRequest bulkRecurringInvoicesRequest, BulkRecurringInvoicesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Custom recurring invoice action
  /// Operation: GET /api/v1/recurring_invoices/{id}/{action}
  /// </summary>
  Task<ApiResponse<RecurringInvoice>> GetAsync(string id, string action, ActionRecurringInvoiceRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Download recurring invoice PDF
  /// Operation: GET /api/v1/recurring_invoice/{invitation_key}/download
  /// </summary>
  Task<Stream> DownloadRecurringInvoiceAsync(string invitationKey, DownloadRecurringInvoiceRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add recurring invoice document
  /// Operation: POST /api/v1/recurring_invoices/{id}/upload
  /// </summary>
  Task<ApiResponse<RecurringInvoice>> UploadRecurringInvoiceAsync(string id, Apigen.InvoiceNinja.Models.UploadRecurringInvoiceRequest uploadRecurringInvoiceRequest, UploadRecurringInvoiceRequest? request = null, CancellationToken cancellationToken = default);

}
