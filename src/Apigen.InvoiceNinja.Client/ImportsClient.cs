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
  /// Pre Import CSV data
  /// Operation: POST /api/v1/preimport
  /// </summary>
  public async Task<ApiResponse<JsonElement>> PreimportAsync(Apigen.InvoiceNinja.Models.PreimportRequest preimportRequest, PreimportRequest? request = null)
  {
    string url = "preimport".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    MultipartFormDataContent content = preimportRequest.ToMultipartContent();
    HttpClientLog.RequestBody(_logger, "POST", "[multipart/form-data]");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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
    ApiResponse<JsonElement>? apiResponse = JsonSerializer.Deserialize<ApiResponse<JsonElement>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<JsonElement>();
  }


  /// <summary>
  /// Import CSV data
  /// Operation: POST /api/v1/import
  /// </summary>
  public async Task<ApiResponse<JsonElement>> PostAsync(Apigen.InvoiceNinja.Models.PostImportRequest postImportRequest, PostImportRequest? request = null)
  {
    string url = "import".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(postImportRequest, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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
    ApiResponse<JsonElement>? apiResponse = JsonSerializer.Deserialize<ApiResponse<JsonElement>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<JsonElement>();
  }


}
