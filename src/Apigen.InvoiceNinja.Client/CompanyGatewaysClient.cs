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
/// Client for company_gateways operations
/// </summary>
public partial class CompanyGatewaysClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal CompanyGatewaysClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Gets a list of company_gateways
  /// Operation: GET /api/v1/company_gateways
  /// </summary>
  public async Task<ApiResponse<CompanyGateway[]>> ListAsync(GetCompanyGatewaysRequest? request = null)
  {
    string url = "company_gateways".BuildUrl(request: request);

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
    ApiResponse<CompanyGateway[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyGateway[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyGateway[]>();
  }


  /// <summary>
  /// Adds a CompanyGateway
  /// Operation: POST /api/v1/company_gateways
  /// </summary>
  public async Task<ApiResponse<CompanyGateway>> CreateAsync(StoreCompanyGatewayRequest? request = null)
  {
    string url = "company_gateways".BuildUrl(request: request);

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
    ApiResponse<CompanyGateway>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyGateway>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyGateway>();
  }


  /// <summary>
  /// Gets a new blank CompanyGateway object
  /// Operation: GET /api/v1/company_gateways/create
  /// </summary>
  public async Task<ApiResponse<CompanyGateway>> GetCompanyGatewaysCreateAsync(GetCompanyGatewaysCreateRequest? request = null)
  {
    string url = "company_gateways/create".BuildUrl(request: request);

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
    ApiResponse<CompanyGateway>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyGateway>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyGateway>();
  }


  /// <summary>
  /// Shows an CompanyGateway
  /// Operation: GET /api/v1/company_gateways/{id}
  /// </summary>
  public async Task<ApiResponse<CompanyGateway>> GetAsync(string id, ShowCompanyGatewayRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "company_gateways/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<CompanyGateway>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyGateway>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyGateway>();
  }


  /// <summary>
  /// Updates an CompanyGateway
  /// Operation: PUT /api/v1/company_gateways/{id}
  /// </summary>
  public async Task<ApiResponse<CompanyGateway>> UpdateAsync(string id, UpdateCompanyGatewayRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "company_gateways/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<CompanyGateway>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyGateway>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyGateway>();
  }


  /// <summary>
  /// Deletes a CompanyGateway
  /// Operation: DELETE /api/v1/company_gateways/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeleteCompanyGatewayRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "company_gateways/{id}".BuildUrl(pathParams, request);

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
  /// Shows an CompanyGateway for editting
  /// Operation: GET /api/v1/company_gateways/{id}/edit
  /// </summary>
  public async Task<ApiResponse<CompanyGateway>> EditCompanyGatewayAsync(string id, EditCompanyGatewayRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "company_gateways/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<CompanyGateway>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyGateway>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyGateway>();
  }


  /// <summary>
  /// Performs bulk actions on an array of company_gateways
  /// Operation: POST /api/v1/company_gateways/bulk
  /// </summary>
  public async Task<ApiResponse<CompanyGateway>> BulkAsync(BulkCompanyGatewaysRequest? request = null)
  {
    string url = "company_gateways/bulk".BuildUrl(request: request);

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
    ApiResponse<CompanyGateway>? apiResponse = JsonSerializer.Deserialize<ApiResponse<CompanyGateway>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<CompanyGateway>();
  }


}
