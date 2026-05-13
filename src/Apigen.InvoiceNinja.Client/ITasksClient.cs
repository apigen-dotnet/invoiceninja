using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for tasks operations
/// </summary>
public partial interface ITasksClient
{
  /// <summary>
  /// List tasks
  /// Operation: GET /api/v1/tasks
  /// </summary>
  Task<ApiResponse<TaskItem[]>> ListAsync(GetTasksRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create task
  /// Operation: POST /api/v1/tasks
  /// </summary>
  Task<ApiResponse<TaskItem>> CreateAsync(Apigen.InvoiceNinja.Models.TaskRequest taskRequest, StoreTaskRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Show task
  /// Operation: GET /api/v1/tasks/{id}
  /// </summary>
  Task<ApiResponse<TaskItem>> GetAsync(string id, ShowTaskRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update task
  /// Operation: PUT /api/v1/tasks/{id}
  /// </summary>
  Task<ApiResponse<TaskItem>> UpdateAsync(string id, Apigen.InvoiceNinja.Models.TaskRequest taskRequest, UpdateTaskRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete task
  /// Operation: DELETE /api/v1/tasks/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteTaskRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Edit task
  /// Operation: GET /api/v1/tasks/{id}/edit
  /// </summary>
  Task<ApiResponse<TaskItem>> EditTaskAsync(string id, EditTaskRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Blank task
  /// Operation: GET /api/v1/tasks/create
  /// </summary>
  Task<ApiResponse<TaskItem>> GetTasksCreateAsync(GetTasksCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Bulk task actions
  /// Operation: POST /api/v1/tasks/bulk
  /// </summary>
  Task<ApiResponse<TaskItem>> BulkAsync(BulkTasksRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Uploads a task document
  /// Operation: POST /api/v1/tasks/{id}/upload
  /// </summary>
  Task<ApiResponse<TaskItem>> UploadTaskAsync(string id, Apigen.InvoiceNinja.Models.UploadTaskRequest uploadTaskRequest, UploadTaskRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Sort tasks on KanBan
  /// Operation: POST /api/v1/tasks/sort
  /// </summary>
  Task SortTasksAsync(Apigen.InvoiceNinja.Models.TaskSortRequest taskSortRequest, SortTasksRequest? request = null, CancellationToken cancellationToken = default);

}
