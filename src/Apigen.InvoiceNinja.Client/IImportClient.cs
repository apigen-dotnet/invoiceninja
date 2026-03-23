using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for import operations
/// </summary>
public interface IImportClient
{
  /// <summary>
  /// Import data from the system
  /// Operation: POST /api/v1/import_json
  /// </summary>
  Task GetImportJsonAsync();

}
