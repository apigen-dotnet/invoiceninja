using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for task_status operations
/// </summary>
public partial interface ITaskItemStatusClient
{
  /// <summary>
  /// Gets a list of task statuses
  /// Operation: GET /api/v1/task_statuses
  /// </summary>
  Task<ApiResponse<TaskItemStatus[]>> GetTaskStatusesAsync(GetTaskStatusesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Adds a TaskStatus
  /// Operation: POST /api/v1/task_statuses
  /// </summary>
  Task<ApiResponse<TaskItemStatus>> StoreTaskStatusAsync(Apigen.InvoiceNinja.Models.TaskItemStatus taskItemStatus, StoreTaskStatusRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets a new blank TaskStatus object
  /// Operation: GET /api/v1/task_statuses/create
  /// </summary>
  Task<ApiResponse<TaskItemStatus>> getTaskStatusesCreateAsync(GetTaskStatusesCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows a TaskStatus Term
  /// Operation: GET /api/v1/task_statuses/{id}
  /// </summary>
  Task<ApiResponse<TaskItemStatus>> GetAsync(string id, ShowTaskStatusRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates a TaskStatus Term
  /// Operation: PUT /api/v1/task_statuses/{id}
  /// </summary>
  Task<ApiResponse<TaskItemStatus>> UpdateAsync(string id, UpdateTaskStatusRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows an TaskStatusfor editting
  /// Operation: GET /api/v1/task_statuses/{id}/edit
  /// </summary>
  Task<ApiResponse<TaskItemStatus>> EditTaskStatussAsync(string id, EditTaskStatussRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Performs bulk actions on an array of task statuses
  /// Operation: POST /api/v1/task_statuses/bulk
  /// </summary>
  Task<ApiResponse<TaskItemStatus>> BulkAsync(BulkTaskStatussRequest? request = null, CancellationToken cancellationToken = default);

}
