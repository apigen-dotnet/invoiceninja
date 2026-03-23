using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for webcron operations
/// </summary>
public interface IWebcronClient
{
  /// <summary>
  /// Executes the task scheduler via a webcron service
  /// Operation: GET /api/v1/webcron
  /// </summary>
  Task ListAsync();

}
