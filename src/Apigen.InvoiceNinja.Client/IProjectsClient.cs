using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for projects operations
/// </summary>
public partial interface IProjectsClient
{
  /// <summary>
  /// List projects
  /// Operation: GET /api/v1/projects
  /// </summary>
  Task<ApiResponse<Project[]>> ListAsync(GetProjectsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create project
  /// Operation: POST /api/v1/projects
  /// </summary>
  Task<ApiResponse<Project>> CreateAsync(Apigen.InvoiceNinja.Models.ProjectRequest projectRequest, StoreProjectRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Show project
  /// Operation: GET /api/v1/projects/{id}
  /// </summary>
  Task<ApiResponse<Project>> GetAsync(string id, ShowProjectRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update project
  /// Operation: PUT /api/v1/projects/{id}
  /// </summary>
  Task<ApiResponse<Project>> UpdateAsync(string id, Apigen.InvoiceNinja.Models.ProjectRequest projectRequest, UpdateProjectRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete project
  /// Operation: DELETE /api/v1/projects/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteProjectRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Edit project
  /// Operation: GET /api/v1/projects/{id}/edit
  /// </summary>
  Task<ApiResponse<Project>> EditProjectAsync(string id, EditProjectRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Blank project
  /// Operation: GET /api/v1/projects/create
  /// </summary>
  Task<ApiResponse<Project>> GetProjectsCreateAsync(GetProjectsCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Bulk project actions
  /// Operation: POST /api/v1/projects/bulk
  /// </summary>
  Task<ApiResponse<Project>> BulkAsync(BulkProjectsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Uploads a project document
  /// Operation: POST /api/v1/projects/{id}/upload
  /// </summary>
  Task<ApiResponse<Project>> UploadProjectAsync(string id, Apigen.InvoiceNinja.Models.UploadProjectRequest uploadProjectRequest, UploadProjectRequest? request = null, CancellationToken cancellationToken = default);

}
