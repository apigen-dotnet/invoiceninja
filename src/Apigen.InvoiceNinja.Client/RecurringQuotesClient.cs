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
/// Client for recurring_quotes operations
/// </summary>
public class RecurringQuotesClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal RecurringQuotesClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Gets a list of recurring_quotes
  /// Operation: GET /api/v1/recurring_quotes
  /// </summary>
  public async Task<ApiResponse<RecurringQuote[]>> ListAsync(GetRecurringQuotesRequest? request = null)
  {
    string url = "recurring_quotes".BuildUrl(request: request);

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
    ApiResponse<RecurringQuote[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringQuote[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringQuote[]>();
  }


  /// <summary>
  /// Adds a RecurringQuote
  /// Operation: POST /api/v1/recurring_quotes
  /// </summary>
  public async Task<ApiResponse<RecurringQuote>> CreateAsync(StoreRecurringQuoteRequest? request = null)
  {
    string url = "recurring_quotes".BuildUrl(request: request);

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
    ApiResponse<RecurringQuote>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringQuote>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringQuote>();
  }


  /// <summary>
  /// Gets a new blank RecurringQuote object
  /// Operation: GET /api/v1/recurring_quotes/create
  /// </summary>
  public async Task<ApiResponse<RecurringQuote>> GetRecurringQuotesCreateAsync(GetRecurringQuotesCreateRequest? request = null)
  {
    string url = "recurring_quotes/create".BuildUrl(request: request);

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
    ApiResponse<RecurringQuote>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringQuote>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringQuote>();
  }


  /// <summary>
  /// Shows an RecurringQuote
  /// Operation: GET /api/v1/recurring_quotes/{id}
  /// </summary>
  public async Task<ApiResponse<RecurringQuote>> GetAsync(string id, ShowRecurringQuoteRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "recurring_quotes/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<RecurringQuote>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringQuote>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringQuote>();
  }


  /// <summary>
  /// Updates an RecurringQuote
  /// Operation: PUT /api/v1/recurring_quotes/{id}
  /// </summary>
  public async Task<ApiResponse<RecurringQuote>> UpdateAsync(string id, UpdateRecurringQuoteRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "recurring_quotes/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<RecurringQuote>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringQuote>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringQuote>();
  }


  /// <summary>
  /// Deletes a RecurringQuote
  /// Operation: DELETE /api/v1/recurring_quotes/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeleteRecurringQuoteRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "recurring_quotes/{id}".BuildUrl(pathParams, request);

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
  /// Shows an RecurringQuote for editting
  /// Operation: GET /api/v1/recurring_quotes/{id}/edit
  /// </summary>
  public async Task<ApiResponse<RecurringQuote>> EditRecurringQuoteAsync(string id, EditRecurringQuoteRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "recurring_quotes/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<RecurringQuote>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringQuote>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringQuote>();
  }


  /// <summary>
  /// Performs bulk actions on an array of recurring_quotes
  /// Operation: POST /api/v1/recurring_quotes/bulk
  /// </summary>
  public async Task<ApiResponse<RecurringQuote>> BulkAsync(BulkRecurringQuotesRequest? request = null)
  {
    string url = "recurring_quotes/bulk".BuildUrl(request: request);

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
    ApiResponse<RecurringQuote>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringQuote>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringQuote>();
  }


  /// <summary>
  /// Performs a custom action on an RecurringQuote
  /// Operation: GET /api/v1/recurring_quotes/{id}/{action}
  /// </summary>
  public async Task<ApiResponse<RecurringQuote>> GetAsync(string id, string action, ActionRecurringQuoteRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["action"] = action
    };
    string url = "recurring_quotes/{id}/{action}".BuildUrl(pathParams, request);

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
    ApiResponse<RecurringQuote>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringQuote>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringQuote>();
  }


}
