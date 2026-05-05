using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for export operations
/// </summary>
public partial interface IExportClient
{
  /// <summary>
  /// Export data from the system
  /// Operation: POST /api/v1/export
  /// </summary>
  Task CreateAsync();

}
