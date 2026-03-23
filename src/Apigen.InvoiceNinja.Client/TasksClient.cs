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
/// Client for tasks operations
/// </summary>
public class TasksClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal TasksClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// List tasks
  /// Operation: GET /api/v1/tasks
  /// </summary>
  public async Task<ApiResponse<TaskItem[]>> ListAsync(GetTasksRequest? request = null)
  {
    string url = "tasks".BuildUrl(request: request);

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
    ApiResponse<TaskItem[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItem[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItem[]>();
  }


  /// <summary>
  /// Create task
  /// Operation: POST /api/v1/tasks
  /// </summary>
  public async Task<ApiResponse<TaskItem>> CreateAsync(StoreTaskRequest? request = null)
  {
    string url = "tasks".BuildUrl(request: request);

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
    ApiResponse<TaskItem>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItem>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItem>();
  }


  /// <summary>
  /// Show task
  /// Operation: GET /api/v1/tasks/{id}
  /// </summary>
  public async Task<ApiResponse<TaskItem>> GetAsync(string id, ShowTaskRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tasks/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<TaskItem>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItem>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItem>();
  }


  /// <summary>
  /// Update task
  /// Operation: PUT /api/v1/tasks/{id}
  /// </summary>
  public async Task<ApiResponse<TaskItem>> UpdateAsync(string id, UpdateTaskRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tasks/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<TaskItem>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItem>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItem>();
  }


  /// <summary>
  /// Delete task
  /// Operation: DELETE /api/v1/tasks/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeleteTaskRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tasks/{id}".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "DELETE", url);
    HttpResponseMessage response = await _httpClient.DeleteAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "DELETE", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// Edit task
  /// Operation: GET /api/v1/tasks/{id}/edit
  /// </summary>
  public async Task<ApiResponse<TaskItem>> EditTaskAsync(string id, EditTaskRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tasks/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<TaskItem>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItem>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItem>();
  }


  /// <summary>
  /// Blank task
  /// Operation: GET /api/v1/tasks/create
  /// </summary>
  public async Task<ApiResponse<TaskItem>> GetTasksCreateAsync(GetTasksCreateRequest? request = null)
  {
    string url = "tasks/create".BuildUrl(request: request);

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
    ApiResponse<TaskItem>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItem>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItem>();
  }


  /// <summary>
  /// Bulk task actions
  /// Operation: POST /api/v1/tasks/bulk
  /// </summary>
  public async Task<ApiResponse<TaskItem>> BulkAsync(BulkTasksRequest? request = null)
  {
    string url = "tasks/bulk".BuildUrl(request: request);

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
    ApiResponse<TaskItem>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItem>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItem>();
  }


  /// <summary>
  /// Uploads a task document
  /// Operation: POST /api/v1/tasks/{id}/upload
  /// </summary>
  public async Task<ApiResponse<TaskItem>> UploadTaskAsync(string id, Apigen.InvoiceNinja.Models.UploadTaskRequest uploadTaskRequest, UploadTaskRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tasks/{id}/upload".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    MultipartFormDataContent content = uploadTaskRequest.ToMultipartContent();
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
    ApiResponse<TaskItem>? apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskItem>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<TaskItem>();
  }


  /// <summary>
  /// Sort tasks on KanBan
  /// Operation: POST /api/v1/tasks/sort
  /// </summary>
  public async Task SortTasksAsync(SortTasksRequest? request = null)
  {
    string url = "tasks/sort".BuildUrl(request: request);

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
