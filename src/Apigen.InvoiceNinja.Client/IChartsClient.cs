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

  /// <summary>
  /// Get chart data v2
  /// Operation: POST /api/v1/charts/totals_v2
  /// </summary>
  Task GetChartTotalsV2Async();

  /// <summary>
  /// Get chart summary v2
  /// Operation: POST /api/v1/charts/chart_summary_v2
  /// </summary>
  Task GetChartSummaryV2Async();

  /// <summary>
  /// Get calculated fields
  /// Operation: POST /api/v1/charts/calculated_fields
  /// </summary>
  Task GetChartCalculatedFieldsAsync();

}
