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
/// Client for imports operations
/// </summary>
public class ImportsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ImportsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Pre Import checks - returns a reference to the job and the headers of the CSV
  /// Operation: POST /api/v1/preimport
  /// </summary>
  public async Task PreimportAsync(PreimportRequest? request = null)
  {
    string url = "preimport".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }
  }


}
