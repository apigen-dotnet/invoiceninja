using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for Purchase Orders operations
/// </summary>
public partial interface IPurchaseOrdersClient
{
  /// <summary>
  /// List purchase orders
  /// Operation: GET /api/v1/purchase_orders
  /// </summary>
  Task<ApiResponse<PurchaseOrder[]>> GetPurchaseOrdersAsync(GetPurchaseOrdersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create purchase order
  /// Operation: POST /api/v1/purchase_orders
  /// </summary>
  Task<ApiResponse<PurchaseOrder>> StorePurchaseOrderAsync(Apigen.InvoiceNinja.Models.PurchaseOrderRequest purchaseOrderRequest, StorePurchaseOrderRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Show purchase order
  /// Operation: GET /api/v1/purchase_orders/{id}
  /// </summary>
  Task<ApiResponse<PurchaseOrder>> GetAsync(string id, ShowPurchaseOrderRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update purchase order
  /// Operation: PUT /api/v1/purchase_order/{id}
  /// </summary>
  Task<ApiResponse<PurchaseOrder>> UpdateAsync(string id, Apigen.InvoiceNinja.Models.PurchaseOrderRequest purchaseOrderRequest, UpdatePurchaseOrderRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete purchase order
  /// Operation: DELETE /api/v1/purchase_order/{id}
  /// </summary>
  Task DeleteAsync(string id, DeletePurchaseOrderRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Edit purchase order
  /// Operation: GET /api/v1/purchase_orders/{id}/edit
  /// </summary>
  Task<ApiResponse<PurchaseOrder>> EditPurchaseOrderAsync(string id, EditPurchaseOrderRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Blank purchase order
  /// Operation: GET /api/v1/purchase_orders/create
  /// </summary>
  Task<ApiResponse<PurchaseOrder>> GetPurchaseOrderCreateAsync(GetPurchaseOrderCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Bulk purchase order action
  /// Operation: POST /api/v1/purchase_orders/bulk
  /// </summary>
  Task BulkAsync(BulkPurchaseOrderssRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Custom purchase order actions
  /// Operation: GET /api/v1/purchase_orders/{id}/{action}
  /// </summary>
  Task<ApiResponse<PurchaseOrder>> GetAsync(string id, string action, ActionPurchaseOrderRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Uploads a purchase order document
  /// Operation: POST /api/v1/purchase_orders/{id}/upload
  /// </summary>
  Task<ApiResponse<PurchaseOrder>> UploadPurchaseOrderAsync(string id, Apigen.InvoiceNinja.Models.UploadPurchaseOrderRequest uploadPurchaseOrderRequest, UploadPurchaseOrderRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Download a purchase order PDF
  /// Operation: GET /api/v1/purchase_order/{invitation_key}/download
  /// </summary>
  Task<Stream> DownloadPurchaseOrderAsync(string invitationKey, DownloadPurchaseOrderRequest? request = null, CancellationToken cancellationToken = default);

}
