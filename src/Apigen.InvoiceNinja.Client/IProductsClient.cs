using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for products operations
/// </summary>
public partial interface IProductsClient
{
  /// <summary>
  /// List products
  /// Operation: GET /api/v1/products
  /// </summary>
  Task<ApiResponse<Product[]>> ListAsync(GetProductsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create Product
  /// Operation: POST /api/v1/products
  /// </summary>
  Task<ApiResponse<Product>> CreateAsync(Apigen.InvoiceNinja.Models.ProductRequest productRequest, StoreProductRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Show product
  /// Operation: GET /api/v1/products/{id}
  /// </summary>
  Task<ApiResponse<Product>> GetAsync(string id, ShowProductRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update product
  /// Operation: PUT /api/v1/products/{id}
  /// </summary>
  Task<ApiResponse<Product>> UpdateAsync(string id, Apigen.InvoiceNinja.Models.ProductRequest productRequest, UpdateProductRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete product
  /// Operation: DELETE /api/v1/products/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteProductRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Edit product
  /// Operation: GET /api/v1/products/{id}/edit
  /// </summary>
  Task<ApiResponse<Product>> EditProductAsync(string id, EditProductRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Blank product
  /// Operation: GET /api/v1/products/create
  /// </summary>
  Task<ApiResponse<Product>> GetProductsCreateAsync(GetProductsCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Bulk product actions
  /// Operation: POST /api/v1/products/bulk
  /// </summary>
  Task<ApiResponse<Product>> BulkAsync(Apigen.InvoiceNinja.Models.ProductBulkAction productBulkAction, BulkProductsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add product document
  /// Operation: POST /api/v1/products/{id}/upload
  /// </summary>
  Task<ApiResponse<Product>> UploadProductAsync(string id, Apigen.InvoiceNinja.Models.UploadProductRequest uploadProductRequest, UploadProductRequest? request = null, CancellationToken cancellationToken = default);

}
