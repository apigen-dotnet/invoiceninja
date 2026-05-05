using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for statics operations
/// </summary>
public partial interface IStaticsClient
{
  /// <summary>
  /// Gets a list of statics
  /// Operation: GET /api/v1/statics
  /// </summary>
  Task ListAsync(GetStaticsRequest? request = null);

}
