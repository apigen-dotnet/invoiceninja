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
/// Client for designs operations
/// </summary>
public class DesignsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal DesignsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Gets a list of designs
  /// Operation: GET /api/v1/designs
  /// </summary>
  public async Task<ApiResponse<Design[]>> ListAsync(GetDesignsRequest? request = null)
  {
    string url = "designs".BuildUrl(request: request);

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
    ApiResponse<Design[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Design[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Design[]>();
  }


  /// <summary>
  /// Adds a design
  /// Operation: POST /api/v1/designs
  /// </summary>
  public async Task<ApiResponse<Design>> CreateAsync(StoreDesignRequest? request = null)
  {
    string url = "designs".BuildUrl(request: request);

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
    ApiResponse<Design>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Design>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Design>();
  }


  /// <summary>
  /// Shows a design
  /// Operation: GET /api/v1/designs/{id}
  /// </summary>
  public async Task<ApiResponse<Design>> GetAsync(string id, ShowDesignRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "designs/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<Design>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Design>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Design>();
  }


  /// <summary>
  /// Updates a design
  /// Operation: PUT /api/v1/designs/{id}
  /// </summary>
  public async Task<ApiResponse<Design>> UpdateAsync(string id, UpdateDesignRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "designs/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<Design>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Design>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Design>();
  }


  /// <summary>
  /// Deletes a design
  /// Operation: DELETE /api/v1/designs/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeleteDesignRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "designs/{id}".BuildUrl(pathParams, request);

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
  /// Shows a design for editting
  /// Operation: GET /api/v1/designs/{id}/edit
  /// </summary>
  public async Task<ApiResponse<Design>> EditDesignAsync(string id, EditDesignRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "designs/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<Design>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Design>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Design>();
  }


  /// <summary>
  /// Gets a new blank design object
  /// Operation: GET /api/v1/designs/create
  /// </summary>
  public async Task<ApiResponse<Design>> GetDesignsCreateAsync(GetDesignsCreateRequest? request = null)
  {
    string url = "designs/create".BuildUrl(request: request);

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
    ApiResponse<Design>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Design>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Design>();
  }


  /// <summary>
  /// Performs bulk actions on an array of designs
  /// Operation: POST /api/v1/designs/bulk
  /// </summary>
  public async Task<ApiResponse<Design>> BulkAsync(BulkDesignsRequest? request = null)
  {
    string url = "designs/bulk".BuildUrl(request: request);

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
    ApiResponse<Design>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Design>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Design>();
  }


}
