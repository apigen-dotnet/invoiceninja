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
/// Client for activities operations
/// </summary>
public class ActivitiesClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ActivitiesClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Returns a list of activities
  /// Operation: GET /api/v1/activities
  /// </summary>
  public async Task<ApiResponse<Activity[]>> ListAsync(GetActivitiesRequest? request = null)
  {
    string url = "activities".BuildUrl(request: request);

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
    ApiResponse<Activity[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Activity[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Activity[]>();
  }


  /// <summary>
  /// Returns a PDF for the given activity
  /// Operation: GET /api/v1/activities/download_entity/{activity_id}
  /// </summary>
  public async Task GetAsync(string activityId, GetActivityHistoricalEntityPdfRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["activity_id"] = activityId
    };
    string url = "activities/download_entity/{activity_id}".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }
  }


}
