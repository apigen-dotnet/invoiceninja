using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for task_statuss operations
/// </summary>
public partial interface ITaskStatussClient
{
  /// <summary>
  /// Deletes a TaskStatus Term
  /// Operation: DELETE /api/v1/task_statuses/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteTaskStatusRequest? request = null);

}
