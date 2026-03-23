using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for products operations
/// </summary>
public interface IProductsClient
{
  /// <summary>
  /// List products
  /// Operation: GET /api/v1/products
  /// </summary>
  Task<ApiResponse<Product[]>> ListAsync(GetProductsRequest? request = null);

  /// <summary>
  /// Create Product
  /// Operation: POST /api/v1/products
  /// </summary>
  Task<ApiResponse<Product>> CreateAsync(Apigen.InvoiceNinja.Models.ProductRequest productRequest, StoreProductRequest? request = null);

  /// <summary>
  /// Show product
  /// Operation: GET /api/v1/products/{id}
  /// </summary>
  Task<ApiResponse<Product>> GetAsync(string id, ShowProductRequest? request = null);

  /// <summary>
  /// Update product
  /// Operation: PUT /api/v1/products/{id}
  /// </summary>
  Task<ApiResponse<Product>> UpdateAsync(string id, Apigen.InvoiceNinja.Models.ProductRequest productRequest, UpdateProductRequest? request = null);

  /// <summary>
  /// Delete product
  /// Operation: DELETE /api/v1/products/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteProductRequest? request = null);

  /// <summary>
  /// Edit product
  /// Operation: GET /api/v1/products/{id}/edit
  /// </summary>
  Task<ApiResponse<Product>> EditProductAsync(string id, EditProductRequest? request = null);

  /// <summary>
  /// Blank product
  /// Operation: GET /api/v1/products/create
  /// </summary>
  Task<ApiResponse<Product>> GetProductsCreateAsync(GetProductsCreateRequest? request = null);

  /// <summary>
  /// Bulk product actions
  /// Operation: POST /api/v1/products/bulk
  /// </summary>
  Task<ApiResponse<Product>> BulkAsync(Apigen.InvoiceNinja.Models.ProductBulkAction productBulkAction, BulkProductsRequest? request = null);

  /// <summary>
  /// Add product document
  /// Operation: POST /api/v1/products/{id}/upload
  /// </summary>
  Task<ApiResponse<Product>> UploadProductAsync(string id, Apigen.InvoiceNinja.Models.UploadProductRequest uploadProductRequest, UploadProductRequest? request = null);

}
