using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for task_schedulers operations
/// </summary>
public partial interface ITaskSchedulersClient
{
  /// <summary>
  /// Task Scheduler Index
  /// Operation: GET /api/v1/task_schedulers
  /// </summary>
  Task ListAsync();

  /// <summary>
  /// Create task scheduler with job 
  /// Operation: POST /api/v1/task_schedulers
  /// </summary>
  Task CreateAsync(Apigen.InvoiceNinja.Models.TaskSchedulerSchema taskSchedulerSchema);

  /// <summary>
  /// Gets a new blank scheduler object
  /// Operation: GET /api/v1/task_schedulers/create
  /// </summary>
  Task<ApiResponse<TaskSchedulerSchema>> GetTaskSchedulerAsync(GetTaskSchedulerRequest? request = null);

  /// <summary>
  /// Show given scheduler
  /// Operation: GET /api/v1/task_schedulers/{id}
  /// </summary>
  Task GetAsync(string id);

  /// <summary>
  /// Update task scheduler 
  /// Operation: PUT /api/v1/task_schedulers/{id}
  /// </summary>
  Task UpdateAsync(string id, Apigen.InvoiceNinja.Models.TaskSchedulerSchema taskSchedulerSchema);

  /// <summary>
  /// Destroy Task Scheduler
  /// Operation: DELETE /api/v1/task_schedulers/{id}
  /// </summary>
  Task DeleteAsync(string id);

  /// <summary>
  /// Performs bulk actions on an array of task_schedulers
  /// Operation: POST /api/v1/task_schedulers/bulk
  /// </summary>
  Task<ApiResponse<TaskSchedulerSchema>> BulkAsync(BulkTaskSchedulerActionsRequest? request = null);

}
