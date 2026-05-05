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
/// Client for task_status operations
/// </summary>
public partial class TaskItemStatusClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal TaskItemStatusClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Gets a list of task statuses
  /// Operation: GET /api/v1/task_statuses
  /// </summary>
  public async Task<ApiResponse<TaskItemStatus[]>> GetTaskStatusesAsync(GetTaskStatusesRequest? request = null)
  {
    string url = "task_statuses".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    ApiResponse<TaskItemStatus[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItemStatus[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItemStatus[]>();
  }


  /// <summary>
  /// Adds a TaskStatus
  /// Operation: POST /api/v1/task_statuses
  /// </summary>
  public async Task<ApiResponse<TaskItemStatus>> StoreTaskStatusAsync(Apigen.InvoiceNinja.Models.TaskItemStatus taskItemStatus, StoreTaskStatusRequest? request = null)
  {
    string url = "task_statuses".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(taskItemStatus, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    ApiResponse<TaskItemStatus>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItemStatus>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItemStatus>();
  }


  /// <summary>
  /// Gets a new blank TaskStatus object
  /// Operation: GET /api/v1/task_statuses/create
  /// </summary>
  public async Task<ApiResponse<TaskItemStatus>> getTaskStatusesCreateAsync(GetTaskStatusesCreateRequest? request = null)
  {
    string url = "task_statuses/create".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    ApiResponse<TaskItemStatus>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItemStatus>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItemStatus>();
  }


  /// <summary>
  /// Shows a TaskStatus Term
  /// Operation: GET /api/v1/task_statuses/{id}
  /// </summary>
  public async Task<ApiResponse<TaskItemStatus>> GetAsync(string id, ShowTaskStatusRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "task_statuses/{id}".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    ApiResponse<TaskItemStatus>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItemStatus>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItemStatus>();
  }


  /// <summary>
  /// Updates a TaskStatus Term
  /// Operation: PUT /api/v1/task_statuses/{id}
  /// </summary>
  public async Task<ApiResponse<TaskItemStatus>> UpdateAsync(string id, UpdateTaskStatusRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "task_statuses/{id}".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    HttpResponseMessage response = await _httpClient.PutAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "PUT", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    ApiResponse<TaskItemStatus>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItemStatus>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItemStatus>();
  }


  /// <summary>
  /// Shows an TaskStatusfor editting
  /// Operation: GET /api/v1/task_statuses/{id}/edit
  /// </summary>
  public async Task<ApiResponse<TaskItemStatus>> EditTaskStatussAsync(string id, EditTaskStatussRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "task_statuses/{id}/edit".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    ApiResponse<TaskItemStatus>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItemStatus>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItemStatus>();
  }


  /// <summary>
  /// Performs bulk actions on an array of task statuses
  /// Operation: POST /api/v1/task_statuses/bulk
  /// </summary>
  public async Task<ApiResponse<TaskItemStatus>> BulkAsync(BulkTaskStatussRequest? request = null)
  {
    string url = "task_statuses/bulk".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    ApiResponse<TaskItemStatus>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItemStatus>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItemStatus>();
  }


}
