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
/// Client for client_gateway_tokens operations
/// </summary>
public class ClientGatewayTokensClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ClientGatewayTokensClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// List of client payment tokens
  /// Operation: GET /api/v1/client_gateway_tokens
  /// </summary>
  public async Task<ApiResponse<ClientGatewayToken[]>> ListAsync(GetClientGatewayTokensRequest? request = null)
  {
    string url = "client_gateway_tokens".BuildUrl(request: request);

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
    ApiResponse<ClientGatewayToken[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<ClientGatewayToken[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<ClientGatewayToken[]>();
  }


  /// <summary>
  /// Adds a client payment token
  /// Operation: POST /api/v1/client_gateway_tokens
  /// </summary>
  public async Task<ApiResponse<ClientGatewayToken>> CreateAsync(StoreClientGatewayTokenRequest? request = null)
  {
    string url = "client_gateway_tokens".BuildUrl(request: request);

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
    ApiResponse<ClientGatewayToken>? apiResponse = JsonSerializer.Deserialize<ApiResponse<ClientGatewayToken>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<ClientGatewayToken>();
  }


  /// <summary>
  /// Shows a client payment token
  /// Operation: GET /api/v1/client_gateway_tokens/{id}
  /// </summary>
  public async Task<ApiResponse<ClientGatewayToken>> GetAsync(string id, ShowClientGatewayTokenRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "client_gateway_tokens/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<ClientGatewayToken>? apiResponse = JsonSerializer.Deserialize<ApiResponse<ClientGatewayToken>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<ClientGatewayToken>();
  }


  /// <summary>
  /// Updates a client payment token
  /// Operation: PUT /api/v1/client_gateway_tokens/{id}
  /// </summary>
  public async Task<ApiResponse<ClientGatewayToken>> UpdateAsync(string id, UpdateClientGatewayTokenRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "client_gateway_tokens/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<ClientGatewayToken>? apiResponse = JsonSerializer.Deserialize<ApiResponse<ClientGatewayToken>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<ClientGatewayToken>();
  }


  /// <summary>
  /// Deletes a client
  /// Operation: DELETE /api/v1/client_gateway_tokens/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeleteClientGatewayTokenRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "client_gateway_tokens/{id}".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "DELETE", url);
    HttpResponseMessage response = await _httpClient.DeleteAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "DELETE", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// Shows a client payment token for editting
  /// Operation: GET /api/v1/client_gateway_tokens/{id}/edit
  /// </summary>
  public async Task<ApiResponse<ClientGatewayToken>> EditClientGatewayTokenAsync(string id, EditClientGatewayTokenRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "client_gateway_tokens/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<ClientGatewayToken>? apiResponse = JsonSerializer.Deserialize<ApiResponse<ClientGatewayToken>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<ClientGatewayToken>();
  }


  /// <summary>
  /// Gets a new blank client payment token object
  /// Operation: GET /api/v1/client_gateway_tokens/create
  /// </summary>
  public async Task<ApiResponse<ClientGatewayToken>> GetClientGatewayTokensCreateAsync(GetClientGatewayTokensCreateRequest? request = null)
  {
    string url = "client_gateway_tokens/create".BuildUrl(request: request);

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
    ApiResponse<ClientGatewayToken>? apiResponse = JsonSerializer.Deserialize<ApiResponse<ClientGatewayToken>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<ClientGatewayToken>();
  }


}
