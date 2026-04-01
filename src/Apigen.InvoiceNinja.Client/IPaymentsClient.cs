using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for payments operations
/// </summary>
public interface IPaymentsClient
{
  /// <summary>
  /// List payments
  /// Operation: GET /api/v1/payments
  /// </summary>
  Task<ApiResponse<Payment[]>> ListAsync(GetPaymentsRequest? request = null);

  /// <summary>
  /// Create payment
  /// Operation: POST /api/v1/payments
  /// </summary>
  Task<ApiResponse<Payment>> CreateAsync(Apigen.InvoiceNinja.Models.PaymentRequest paymentRequest, StorePaymentRequest? request = null);

  /// <summary>
  /// Show payment
  /// Operation: GET /api/v1/payments/{id}
  /// </summary>
  Task<ApiResponse<Payment>> GetAsync(string id, ShowPaymentRequest? request = null);

  /// <summary>
  /// Update payment
  /// Operation: PUT /api/v1/payments/{id}
  /// </summary>
  Task<ApiResponse<Payment>> UpdateAsync(string id, UpdatePaymentRequest? request = null);

  /// <summary>
  /// Delete payment
  /// Operation: DELETE /api/v1/payments/{id}
  /// </summary>
  Task DeleteAsync(string id, DeletePaymentRequest? request = null);

  /// <summary>
  /// Edit payment
  /// Operation: GET /api/v1/payments/{id}/edit
  /// </summary>
  Task<ApiResponse<Payment>> EditPaymentAsync(string id, EditPaymentRequest? request = null);

  /// <summary>
  /// Blank payment
  /// Operation: GET /api/v1/payments/create
  /// </summary>
  Task<ApiResponse<Payment>> GetPaymentsCreateAsync(GetPaymentsCreateRequest? request = null);

  /// <summary>
  /// Refund payment
  /// Operation: POST /api/v1/payments/refund
  /// </summary>
  Task<ApiResponse<Payment>> StoreRefundAsync(Apigen.InvoiceNinja.Models.PaymentRequest payment, StoreRefundRequest? request = null);

  /// <summary>
  /// Bulk payment actions
  /// Operation: POST /api/v1/payments/bulk
  /// </summary>
  Task<ApiResponse<Payment>> BulkAsync(BulkPaymentsRequest? request = null);

  /// <summary>
  /// Custom payment actions
  /// Operation: GET /api/v1/payments/{id}/{action}
  /// </summary>
  Task<ApiResponse<Payment>> GetAsync(string id, string action, ActionPaymentRequest? request = null);

  /// <summary>
  /// Upload a payment document
  /// Operation: POST /api/v1/payments/{id}/upload
  /// </summary>
  Task<ApiResponse<Payment>> UploadPaymentAsync(string id, Apigen.InvoiceNinja.Models.UploadPaymentRequest uploadPaymentRequest, UploadPaymentRequest? request = null);

}
