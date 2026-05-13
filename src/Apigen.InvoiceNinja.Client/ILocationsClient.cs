using System.Text.Json;
using System.Threading;
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
  Task<ApiResponse<Location[]>> ListAsync(GetLocationsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create location
  /// Operation: POST /api/v1/locations
  /// </summary>
  Task<ApiResponse<Location>> CreateAsync(Apigen.InvoiceNinja.Models.LocationRequest locationRequest, StoreLocationRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Show location
  /// Operation: GET /api/v1/locations/{id}
  /// </summary>
  Task<ApiResponse<Location>> GetAsync(string id, ShowLocationRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update location
  /// Operation: PUT /api/v1/locations/{id}
  /// </summary>
  Task<ApiResponse<Location>> UpdateAsync(string id, Apigen.InvoiceNinja.Models.LocationRequest locationRequest, UpdateLocationRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete location
  /// Operation: DELETE /api/v1/locations/{id}
  /// </summary>
  Task DeleteAsync(string id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Blank Location
  /// Operation: GET /api/v1/locations/create
  /// </summary>
  Task<ApiResponse<Location>> GetLocationsCreateAsync(GetLocationsCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Bulk location actions
  /// Operation: POST /api/v1/locations/bulk
  /// </summary>
  Task<ApiResponse<Location>> BulkAsync(Apigen.InvoiceNinja.Models.GenericBulkAction genericBulkAction, BulkLocationsRequest? request = null, CancellationToken cancellationToken = default);

}
