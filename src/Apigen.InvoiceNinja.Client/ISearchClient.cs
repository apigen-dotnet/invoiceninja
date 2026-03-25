using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for search operations
/// </summary>
public interface ISearchClient
{
  /// <summary>
  /// Search
  /// Operation: POST /api/v1/search
  /// </summary>
  Task CreateAsync();

}
