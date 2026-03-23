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
/// Client for templates operations
/// </summary>
public class TemplatesClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal TemplatesClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Returns a entity template with the template variables replaced with the Entities
  /// Operation: POST /api/v1/templates
  /// </summary>
  public async Task<ApiResponse<Template>> CreateAsync(Apigen.InvoiceNinja.Models.GetShowTemplateRequest getShowTemplateRequest, GetShowTemplateRequest? request = null)
  {
    string url = "templates".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(getShowTemplateRequest, JsonConfig.Default);
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
    ApiResponse<Template>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Template>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Template>();
  }


}
