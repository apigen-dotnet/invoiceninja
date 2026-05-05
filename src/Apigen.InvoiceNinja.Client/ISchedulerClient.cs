using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for scheduler operations
/// </summary>
public partial interface ISchedulerClient
{
  /// <summary>
  /// Get scheduler status
  /// Operation: GET /api/v1/scheduler
  /// </summary>
  Task ListAsync();

}
