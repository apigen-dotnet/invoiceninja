using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Client for company_ledger operations
/// </summary>
public class CompanyLedgerClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal CompanyLedgerClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Gets a list of company_ledger
  /// Operation: GET /api/v1/company_ledger
  /// </summary>
  public async Task<ApiResponse<CompanyLedger[]>> ListAsync(GetCompanyLedgerRequest? request = null)
  {
    string url = "company_ledger".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    ApiResponse<CompanyLedger[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyLedger[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyLedger[]>();
  }


}
