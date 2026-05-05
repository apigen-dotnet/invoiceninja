using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for locations operations
/// </summary>
public partial interface ILocationsClient
{
  /// <summary>
  /// List locations
  /// Operation: GET /api/v1/locations
  /// </summary>
  Task<ApiResponse<Location[]>> ListAsync(GetLocationsRequest? request = null);

  /// <summary>
  /// Create location
  /// Operation: POST /api/v1/locations
  /// </summary>
  Task<ApiResponse<Location>> CreateAsync(Apigen.InvoiceNinja.Models.LocationRequest locationRequest, StoreLocationRequest? request = null);

  /// <summary>
  /// Show location
  /// Operation: GET /api/v1/locations/{id}
  /// </summary>
  Task<ApiResponse<Location>> GetAsync(string id, ShowLocationRequest? request = null);

  /// <summary>
  /// Update location
  /// Operation: PUT /api/v1/locations/{id}
  /// </summary>
  Task<ApiResponse<Location>> UpdateAsync(string id, Apigen.InvoiceNinja.Models.LocationRequest locationRequest, UpdateLocationRequest? request = null);

  /// <summary>
  /// Delete location
  /// Operation: DELETE /api/v1/locations/{id}
  /// </summary>
  Task DeleteAsync(string id);

  /// <summary>
  /// Blank Location
  /// Operation: GET /api/v1/locations/create
  /// </summary>
  Task<ApiResponse<Location>> GetLocationsCreateAsync(GetLocationsCreateRequest? request = null);

  /// <summary>
  /// Bulk location actions
  /// Operation: POST /api/v1/locations/bulk
  /// </summary>
  Task<ApiResponse<Location>> BulkAsync(Apigen.InvoiceNinja.Models.GenericBulkAction genericBulkAction, BulkLocationsRequest? request = null);

}
