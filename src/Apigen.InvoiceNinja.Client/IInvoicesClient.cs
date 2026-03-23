using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for invoices operations
/// </summary>
public interface IInvoicesClient
{
  /// <summary>
  /// List invoices
  /// Operation: GET /api/v1/invoices
  /// </summary>
  Task<ApiResponse<Invoice[]>> ListAsync(GetInvoicesRequest? request = null);

  /// <summary>
  /// Create invoice
  /// Operation: POST /api/v1/invoices
  /// </summary>
  Task<ApiResponse<Invoice>> CreateAsync(Apigen.InvoiceNinja.Models.InvoiceRequest invoiceRequest, StoreInvoiceRequest? request = null);

  /// <summary>
  /// Show invoice
  /// Operation: GET /api/v1/invoices/{id}
  /// </summary>
  Task<ApiResponse<Invoice>> GetAsync(string id, ShowInvoiceRequest? request = null);

  /// <summary>
  /// Update invoice
  /// Operation: PUT /api/v1/invoices/{id}
  /// </summary>
  Task<ApiResponse<Invoice>> UpdateAsync(string id, UpdateInvoiceRequest? request = null);

  /// <summary>
  /// Delete invoice
  /// Operation: DELETE /api/v1/invoices/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteInvoiceRequest? request = null);

  /// <summary>
  /// Edit invoice
  /// Operation: GET /api/v1/invoices/{id}/edit
  /// </summary>
  Task<ApiResponse<Invoice>> EditInvoiceAsync(string id, EditInvoiceRequest? request = null);

  /// <summary>
  /// Blank invoice
  /// Operation: GET /api/v1/invoices/create
  /// </summary>
  Task<ApiResponse<Invoice>> getBlankInvoiceAsync();

  /// <summary>
  /// Bulk invoice actions
  /// Operation: POST /api/v1/invoices/bulk
  /// </summary>
  Task BulkAsync(Apigen.InvoiceNinja.Models.BulkInvoicesRequest bulkInvoicesRequest, BulkInvoicesRequest? request = null);

  /// <summary>
  /// Custom invoice action
  /// Operation: GET /api/v1/invoices/{id}/{action}
  /// </summary>
  Task<ApiResponse<Invoice>> GetAsync(string id, string action, ActionInvoiceRequest? request = null);

  /// <summary>
  /// Download invoice PDF
  /// Operation: GET /api/v1/invoice/{invitation_key}/download
  /// </summary>
  Task downloadInvoiceAsync(string invitationKey, DownloadInvoiceRequest? request = null);

  /// <summary>
  /// Download delivery note
  /// Operation: GET /api/v1/invoices/{id}/delivery_note
  /// </summary>
  Task getInvoiceDeliveryNoteAsync(string id, GetInvoiceDeliveryNoteRequest? request = null);

  /// <summary>
  /// Add invoice document
  /// Operation: POST /api/v1/invoices/{id}/upload
  /// </summary>
  Task<ApiResponse<Invoice>> PostinvoicesAsync(string id, PostinvoicesRequest? request = null);

}
