using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for charts operations
/// </summary>
public interface IChartsClient
{
  /// <summary>
  /// Get chart data
  /// Operation: POST /api/v1/charts/totals
  /// </summary>
  Task GetChartTotalsAsync(GetChartTotalsRequest? request = null);

}
