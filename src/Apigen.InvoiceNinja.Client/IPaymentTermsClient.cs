using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for payment_terms operations
/// </summary>
public partial interface IPaymentTermsClient
{
  /// <summary>
  /// Gets a list of payment terms
  /// Operation: GET /api/v1/payment_terms
  /// </summary>
  Task<ApiResponse<PaymentTerm[]>> ListAsync(GetPaymentTermsRequest? request = null);

  /// <summary>
  /// Adds a Payment
  /// Operation: POST /api/v1/payment_terms
  /// </summary>
  Task<ApiResponse<PaymentTerm>> CreateAsync(Apigen.InvoiceNinja.Models.PaymentTerm paymentTerm, StorePaymentTermRequest? request = null);

  /// <summary>
  /// Gets a new blank PaymentTerm object
  /// Operation: GET /api/v1/payment_terms/create
  /// </summary>
  Task<ApiResponse<Payment>> GetPaymentTermsCreateAsync(GetPaymentTermsCreateRequest? request = null);

  /// <summary>
  /// Shows a Payment Term
  /// Operation: GET /api/v1/payment_terms/{id}
  /// </summary>
  Task<ApiResponse<PaymentTerm>> GetAsync(string id, ShowPaymentTermRequest? request = null);

  /// <summary>
  /// Updates a Payment Term
  /// Operation: PUT /api/v1/payment_terms/{id}
  /// </summary>
  Task<ApiResponse<PaymentTerm>> UpdateAsync(string id, UpdatePaymentTermRequest? request = null);

  /// <summary>
  /// Shows an Payment Term for editting
  /// Operation: GET /api/v1/payment_terms/{id}/edit
  /// </summary>
  Task<ApiResponse<PaymentTerm>> EditPaymentTermsAsync(string id, EditPaymentTermsRequest? request = null);

  /// <summary>
  /// Performs bulk actions on an array of payment terms
  /// Operation: POST /api/v1/payment_terms/bulk
  /// </summary>
  Task<ApiResponse<PaymentTerm>> BulkAsync(BulkPaymentTermsRequest? request = null);

}
