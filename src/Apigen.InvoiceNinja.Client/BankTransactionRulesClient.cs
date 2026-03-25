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
/// Client for bank_transaction_rules operations
/// </summary>
public class BankTransactionRulesClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal BankTransactionRulesClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Gets a list of bank_transaction_rules
  /// Operation: GET /api/v1/bank_transaction_rules
  /// </summary>
  public async Task<ApiResponse<BankTransactionRule[]>> ListAsync(GetBankTransactionRulesRequest? request = null)
  {
    string url = "bank_transaction_rules".BuildUrl(request: request);

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
    ApiResponse<BankTransactionRule[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankTransactionRule[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankTransactionRule[]>();
  }


  /// <summary>
  /// Adds a bank_transaction rule
  /// Operation: POST /api/v1/bank_transaction_rules
  /// </summary>
  public async Task<ApiResponse<BankTransactionRule>> CreateAsync(StoreBankTransactionRuleRequest? request = null)
  {
    string url = "bank_transaction_rules".BuildUrl(request: request);

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
    ApiResponse<BankTransactionRule>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankTransactionRule>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankTransactionRule>();
  }


  /// <summary>
  /// Shows a bank_transaction
  /// Operation: GET /api/v1/bank_transaction_rules/{id}
  /// </summary>
  public async Task<ApiResponse<BankTransactionRule>> GetAsync(string id, ShowBankTransactionRuleRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "bank_transaction_rules/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<BankTransactionRule>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankTransactionRule>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankTransactionRule>();
  }


  /// <summary>
  /// Updates a bank_transaction Rule
  /// Operation: PUT /api/v1/bank_transaction_rules/{id}
  /// </summary>
  public async Task<ApiResponse<BankTransactionRule>> UpdateAsync(string id, UpdateBankTransactionRuleRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "bank_transaction_rules/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<BankTransactionRule>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankTransactionRule>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankTransactionRule>();
  }


  /// <summary>
  /// Deletes a bank_transaction rule
  /// Operation: DELETE /api/v1/bank_transaction_rules/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeleteBankTransactionRuleRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "bank_transaction_rules/{id}".BuildUrl(pathParams, request);

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
  /// Shows a bank_transaction for editing
  /// Operation: GET /api/v1/bank_transaction_rules/{id}/edit
  /// </summary>
  public async Task<ApiResponse<BankTransactionRule>> EditBankTransactionRuleAsync(string id, EditBankTransactionRuleRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "bank_transaction_rules/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<BankTransactionRule>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankTransactionRule>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankTransactionRule>();
  }


  /// <summary>
  /// Gets a new blank bank_transaction rule object
  /// Operation: GET /api/v1/bank_transaction_rules/create
  /// </summary>
  public async Task<ApiResponse<BankTransactionRule>> GetBankTransactionRulesCreateAsync(GetBankTransactionRulesCreateRequest? request = null)
  {
    string url = "bank_transaction_rules/create".BuildUrl(request: request);

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
    ApiResponse<BankTransactionRule>? apiResponse = JsonSerializer.Deserialize<ApiResponse<BankTransactionRule>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<BankTransactionRule>();
  }


  /// <summary>
  /// Performs bulk actions on an array of bank_transaction rules
  /// Operation: POST /api/v1/bank_transaction_rules/bulk
  /// </summary>
  public async Task BulkAsync(BulkBankTransactionRulesRequest? request = null)
  {
    string url = "bank_transaction_rules/bulk".BuildUrl(request: request);

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
