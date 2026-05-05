using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for one_time_token operations
/// </summary>
public partial interface IOneTimeTokenClient
{
  /// <summary>
  /// Attempts to create a one time token
  /// Operation: POST /api/v1/one_time_token
  /// </summary>
  Task CreateAsync();

}
