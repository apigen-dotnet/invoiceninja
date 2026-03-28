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
/// Client for bank_integrations operations
/// </summary>
public class BankIntegrationsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal BankIntegrationsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Returns a list of Bank Integrations
  /// Operation: GET /api/v1/bank_integrations
  /// </summary>
  public async Task<ApiResponse<BankIntegration[]>> ListAsync(GetBankIntegrationsRequest? request = null)
  {
    string url = "bank_integrations".BuildUrl(request: request);

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
    ApiResponse<BankIntegration[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankIntegration[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankIntegration[]>();
  }


  /// <summary>
  /// Adds a bank_integration
  /// Operation: POST /api/v1/bank_integrations
  /// </summary>
  public async Task<ApiResponse<BankIntegration>> CreateAsync(StoreBankIntegrationRequest? request = null)
  {
    string url = "bank_integrations".BuildUrl(request: request);

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
    ApiResponse<BankIntegration>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankIntegration>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankIntegration>();
  }


  /// <summary>
  /// Shows a bank_integration
  /// Operation: GET /api/v1/bank_integrations/{id}
  /// </summary>
  public async Task<ApiResponse<BankIntegration>> GetAsync(string id, ShowBankIntegrationRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "bank_integrations/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<BankIntegration>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankIntegration>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankIntegration>();
  }


  /// <summary>
  /// Updates a bank_integration
  /// Operation: PUT /api/v1/bank_integrations/{id}
  /// </summary>
  public async Task<ApiResponse<BankIntegration>> UpdateAsync(string id, UpdateBankIntegrationRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "bank_integrations/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<BankIntegration>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankIntegration>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankIntegration>();
  }


  /// <summary>
  /// Deletes a bank_integration
  /// Operation: DELETE /api/v1/bank_integrations/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeleteBankIntegrationRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "bank_integrations/{id}".BuildUrl(pathParams, request);

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
  /// Shows a bank_integration for editing
  /// Operation: GET /api/v1/bank_integrations/{id}/edit
  /// </summary>
  public async Task<ApiResponse<BankIntegration>> EditBankIntegrationAsync(string id, EditBankIntegrationRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "bank_integrations/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<BankIntegration>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankIntegration>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankIntegration>();
  }


  /// <summary>
  /// Gets a new blank bank_integration object
  /// Operation: GET /api/v1/bank_integrations/create
  /// </summary>
  public async Task<ApiResponse<BankIntegration>> GetBankIntegrationsCreateAsync(GetBankIntegrationsCreateRequest? request = null)
  {
    string url = "bank_integrations/create".BuildUrl(request: request);

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
    ApiResponse<BankIntegration>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankIntegration>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankIntegration>();
  }


  /// <summary>
  /// Performs bulk actions on an array of bank_integrations
  /// Operation: POST /api/v1/bank_integrations/bulk
  /// </summary>
  public async Task BulkAsync(BulkBankIntegrationsRequest? request = null)
  {
    string url = "bank_integrations/bulk".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// Gets the list of accounts from the remote server
  /// Operation: POST /api/v1/bank_integrations/refresh_accounts
  /// </summary>
  public async Task<ApiResponse<BankIntegration>> GetRefreshAccountsAsync(GetRefreshAccountsRequest? request = null)
  {
    string url = "bank_integrations/refresh_accounts".BuildUrl(request: request);

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
    ApiResponse<BankIntegration>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankIntegration>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankIntegration>();
  }


  /// <summary>
  /// Removes an account from the integration
  /// Operation: POST /api/v1/bank_integrations/remove_account/account_id
  /// </summary>
  public async Task<ApiResponse<BankIntegration>> GetRemoveAccountAsync(GetRemoveAccountRequest? request = null)
  {
    string url = "bank_integrations/remove_account/account_id".BuildUrl(request: request);

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
    ApiResponse<BankIntegration>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankIntegration>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankIntegration>();
  }


  /// <summary>
  /// Retrieve transactions for a account
  /// Operation: POST /api/v1/bank_integrations/get_transactions/account_id
  /// </summary>
  public async Task<ApiResponse<BankIntegration>> GetAccountTransactionsAsync(GetAccountTransactionsRequest? request = null)
  {
    string url = "bank_integrations/get_transactions/account_id".BuildUrl(request: request);

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
    ApiResponse<BankIntegration>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankIntegration>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankIntegration>();
  }


}
