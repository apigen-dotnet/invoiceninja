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
/// Client for yodlee operations
/// </summary>
public class YodleeClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal YodleeClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Yodlee Webhook
  /// Operation: POST /api/v1/yodlee/refresh
  /// </summary>
  public async Task<ApiResponse<Credit>> YodleeRefreshWebhookAsync()
  {
    string url = "yodlee/refresh";

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    ApiResponse<Credit>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Credit>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Credit>();
  }


}
