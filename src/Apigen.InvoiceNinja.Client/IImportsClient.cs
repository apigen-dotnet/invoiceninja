using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for imports operations
/// </summary>
public interface IImportsClient
{
  /// <summary>
  /// Pre Import checks - returns a reference to the job and the headers of the CSV
  /// Operation: POST /api/v1/preimport
  /// </summary>
  Task PreimportAsync(PreimportRequest? request = null);

}
