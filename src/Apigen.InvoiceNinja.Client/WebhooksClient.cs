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
/// Client for webhooks operations
/// </summary>
public class WebhooksClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal WebhooksClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Gets a list of Webhooks
  /// Operation: GET /api/v1/webhooks
  /// </summary>
  public async Task<ApiResponse<Webhook[]>> ListAsync(GetWebhooksRequest? request = null)
  {
    string url = "webhooks".BuildUrl(request: request);

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
    ApiResponse<Webhook[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Webhook[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Webhook[]>();
  }


  /// <summary>
  /// Adds a Webhook
  /// Operation: POST /api/v1/webhooks
  /// </summary>
  public async Task<ApiResponse<Webhook>> CreateAsync(StoreWebhookRequest? request = null)
  {
    string url = "webhooks".BuildUrl(request: request);

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
    ApiResponse<Webhook>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Webhook>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Webhook>();
  }


  /// <summary>
  /// Shows a Webhook
  /// Operation: GET /api/v1/webhooks/{id}
  /// </summary>
  public async Task<ApiResponse<Webhook>> GetAsync(string id, ShowWebhookRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "webhooks/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<Webhook>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Webhook>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Webhook>();
  }


  /// <summary>
  /// Updates a Webhook
  /// Operation: PUT /api/v1/webhooks/{id}
  /// </summary>
  public async Task<ApiResponse<Webhook>> UpdateAsync(string id, UpdateWebhookRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "webhooks/{id}".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    HttpResponseMessage response = await _httpClient.PutAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "PUT", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    ApiResponse<Webhook>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Webhook>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Webhook>();
  }


  /// <summary>
  /// Shows a Webhook for editting
  /// Operation: GET /api/v1/webhooks/{id}/edit
  /// </summary>
  public async Task<ApiResponse<Webhook>> EditWebhookAsync(string id, EditWebhookRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "webhooks/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<Webhook>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Webhook>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Webhook>();
  }


  /// <summary>
  /// Gets a new blank Webhook object
  /// Operation: GET /api/v1/webhooks/create
  /// </summary>
  public async Task<ApiResponse<Webhook>> GetWebhooksCreateAsync(GetWebhooksCreateRequest? request = null)
  {
    string url = "webhooks/create".BuildUrl(request: request);

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
    ApiResponse<Webhook>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Webhook>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Webhook>();
  }


  /// <summary>
  /// Performs bulk actions on an array of Webhooks
  /// Operation: POST /api/v1/webhooks/bulk
  /// </summary>
  public async Task<ApiResponse<Webhook>> BulkAsync(Apigen.InvoiceNinja.Models.BulkWebhooksRequest bulkWebhooksRequest, BulkWebhooksRequest? request = null)
  {
    string url = "webhooks/bulk".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(bulkWebhooksRequest, JsonConfig.Default);
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
    ApiResponse<Webhook>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Webhook>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Webhook>();
  }


}
