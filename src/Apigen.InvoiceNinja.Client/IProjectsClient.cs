using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for projects operations
/// </summary>
public interface IProjectsClient
{
  /// <summary>
  /// List projects
  /// Operation: GET /api/v1/projects
  /// </summary>
  Task<ApiResponse<Project[]>> ListAsync(GetProjectsRequest? request = null);

  /// <summary>
  /// Create project
  /// Operation: POST /api/v1/projects
  /// </summary>
  Task<ApiResponse<Project>> CreateAsync(StoreProjectRequest? request = null);

  /// <summary>
  /// Show project
  /// Operation: GET /api/v1/projects/{id}
  /// </summary>
  Task<ApiResponse<Project>> GetAsync(string id, ShowProjectRequest? request = null);

  /// <summary>
  /// Update project
  /// Operation: PUT /api/v1/projects/{id}
  /// </summary>
  Task<ApiResponse<Project>> UpdateAsync(string id, UpdateProjectRequest? request = null);

  /// <summary>
  /// Delete project
  /// Operation: DELETE /api/v1/projects/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteProjectRequest? request = null);

  /// <summary>
  /// Edit project
  /// Operation: GET /api/v1/projects/{id}/edit
  /// </summary>
  Task<ApiResponse<Project>> EditProjectAsync(string id, EditProjectRequest? request = null);

  /// <summary>
  /// Blank project
  /// Operation: GET /api/v1/projects/create
  /// </summary>
  Task<ApiResponse<Project>> GetProjectsCreateAsync(GetProjectsCreateRequest? request = null);

  /// <summary>
  /// Bulk project actions
  /// Operation: POST /api/v1/projects/bulk
  /// </summary>
  Task<ApiResponse<Project>> BulkAsync(BulkProjectsRequest? request = null);

  /// <summary>
  /// Uploads a project document
  /// Operation: POST /api/v1/projects/{id}/upload
  /// </summary>
  Task<ApiResponse<Project>> UploadProjectAsync(string id, Apigen.InvoiceNinja.Models.UploadProjectRequest uploadProjectRequest, UploadProjectRequest? request = null);

}
