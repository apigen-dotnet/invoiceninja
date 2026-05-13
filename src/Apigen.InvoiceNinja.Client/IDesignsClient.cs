using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for designs operations
/// </summary>
public partial interface IDesignsClient
{
  /// <summary>
  /// Gets a list of designs
  /// Operation: GET /api/v1/designs
  /// </summary>
  Task<ApiResponse<Design[]>> ListAsync(GetDesignsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Adds a design
  /// Operation: POST /api/v1/designs
  /// </summary>
  Task<ApiResponse<Design>> CreateAsync(StoreDesignRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows a design
  /// Operation: GET /api/v1/designs/{id}
  /// </summary>
  Task<ApiResponse<Design>> GetAsync(string id, ShowDesignRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates a design
  /// Operation: PUT /api/v1/designs/{id}
  /// </summary>
  Task<ApiResponse<Design>> UpdateAsync(string id, UpdateDesignRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes a design
  /// Operation: DELETE /api/v1/designs/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteDesignRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows a design for editting
  /// Operation: GET /api/v1/designs/{id}/edit
  /// </summary>
  Task<ApiResponse<Design>> EditDesignAsync(string id, EditDesignRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets a new blank design object
  /// Operation: GET /api/v1/designs/create
  /// </summary>
  Task<ApiResponse<Design>> GetDesignsCreateAsync(GetDesignsCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Performs bulk actions on an array of designs
  /// Operation: POST /api/v1/designs/bulk
  /// </summary>
  Task<ApiResponse<Design>> BulkAsync(BulkDesignsRequest? request = null, CancellationToken cancellationToken = default);

}
