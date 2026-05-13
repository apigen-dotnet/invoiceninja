using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for vendors operations
/// </summary>
public partial interface IVendorsClient
{
  /// <summary>
  /// List vendors
  /// Operation: GET /api/v1/vendors
  /// </summary>
  Task<ApiResponse<Vendor[]>> ListAsync(GetVendorsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create vendor
  /// Operation: POST /api/v1/vendors
  /// </summary>
  Task<ApiResponse<Vendor>> CreateAsync(Apigen.InvoiceNinja.Models.VendorRequest vendorRequest, StoreVendorRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Show vendor
  /// Operation: GET /api/v1/vendors/{id}
  /// </summary>
  Task<ApiResponse<Vendor>> GetAsync(string id, ShowVendorRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update vendor
  /// Operation: PUT /api/v1/vendors/{id}
  /// </summary>
  Task<ApiResponse<Vendor>> UpdateAsync(string id, Apigen.InvoiceNinja.Models.VendorRequest vendorRequest, UpdateVendorRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete vendor
  /// Operation: DELETE /api/v1/vendors/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteVendorRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Edit vendor
  /// Operation: GET /api/v1/vendors/{id}/edit
  /// </summary>
  Task<ApiResponse<Vendor>> EditVendorAsync(string id, EditVendorRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Blank vendor
  /// Operation: GET /api/v1/vendors/create
  /// </summary>
  Task<ApiResponse<Vendor>> GetVendorsCreateAsync(GetVendorsCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Bulk vendor actions
  /// Operation: POST /api/v1/vendors/bulk
  /// </summary>
  Task<ApiResponse<Vendor>> BulkAsync(BulkVendorsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Uploads a vendor document
  /// Operation: POST /api/v1/vendors/{id}/upload
  /// </summary>
  Task<ApiResponse<Vendor>> UploadVendorAsync(string id, Apigen.InvoiceNinja.Models.UploadVendorRequest uploadVendorRequest, UploadVendorRequest? request = null, CancellationToken cancellationToken = default);

}
