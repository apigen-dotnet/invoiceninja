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
/// Client for tokens operations
/// </summary>
public class TokensClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal TokensClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Gets a list of company tokens
  /// Operation: GET /api/v1/tokens
  /// </summary>
  public async Task<ApiResponse<CompanyToken[]>> ListAsync(GetTokensRequest? request = null)
  {
    string url = "tokens".BuildUrl(request: request);

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
    ApiResponse<CompanyToken[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyToken[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyToken[]>();
  }


  /// <summary>
  /// Adds a token
  /// Operation: POST /api/v1/tokens
  /// </summary>
  public async Task<ApiResponse<CompanyToken>> CreateAsync(StoreTokenRequest? request = null)
  {
    string url = "tokens".BuildUrl(request: request);

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
    ApiResponse<CompanyToken>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyToken>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyToken>();
  }


  /// <summary>
  /// Shows a token
  /// Operation: GET /api/v1/tokens/{id}
  /// </summary>
  public async Task<ApiResponse<CompanyToken>> GetAsync(string id, ShowTokenRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tokens/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<CompanyToken>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyToken>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyToken>();
  }


  /// <summary>
  /// Updates a token
  /// Operation: PUT /api/v1/tokens/{id}
  /// </summary>
  public async Task<ApiResponse<CompanyToken>> UpdateAsync(string id, UpdateTokenRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tokens/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<CompanyToken>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyToken>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyToken>();
  }


  /// <summary>
  /// Deletes a token
  /// Operation: DELETE /api/v1/tokens/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeleteTokenRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tokens/{id}".BuildUrl(pathParams, request);

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
  /// Shows a token for editting
  /// Operation: GET /api/v1/tokens/{id}/edit
  /// </summary>
  public async Task<ApiResponse<CompanyToken>> EditTokenAsync(string id, EditTokenRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tokens/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<CompanyToken>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyToken>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyToken>();
  }


  /// <summary>
  /// Gets a new blank token object
  /// Operation: GET /api/v1/tokens/create
  /// </summary>
  public async Task<ApiResponse<CompanyToken>> GetTokensCreateAsync(GetTokensCreateRequest? request = null)
  {
    string url = "tokens/create".BuildUrl(request: request);

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
    ApiResponse<CompanyToken>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyToken>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyToken>();
  }


  /// <summary>
  /// Performs bulk actions on an array of tokens
  /// Operation: POST /api/v1/tokens/bulk
  /// </summary>
  public async Task<ApiResponse<CompanyToken>> BulkAsync(BulkTokensRequest? request = null)
  {
    string url = "tokens/bulk".BuildUrl(request: request);

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
    ApiResponse<CompanyToken>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyToken>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyToken>();
  }


}
