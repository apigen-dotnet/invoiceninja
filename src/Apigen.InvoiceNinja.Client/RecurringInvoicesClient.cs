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
/// Client for Recurring Invoices operations
/// </summary>
public partial class RecurringInvoicesClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal RecurringInvoicesClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// List recurring invoices
  /// Operation: GET /api/v1/recurring_invoices
  /// </summary>
  public async Task<ApiResponse<RecurringInvoice[]>> GetRecurringInvoicesAsync(GetRecurringInvoicesRequest? request = null)
  {
    string url = "recurring_invoices".BuildUrl(request: request);

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
    ApiResponse<RecurringInvoice[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringInvoice[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringInvoice[]>();
  }


  /// <summary>
  /// Create recurring invoice
  /// Operation: POST /api/v1/recurring_invoices
  /// </summary>
  public async Task<ApiResponse<RecurringInvoice>> StoreRecurringInvoiceAsync(Apigen.InvoiceNinja.Models.RecurringInvoiceRequest recurringInvoiceRequest, StoreRecurringInvoiceRequest? request = null)
  {
    string url = "recurring_invoices".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(recurringInvoiceRequest, JsonConfig.Default);
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
    ApiResponse<RecurringInvoice>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringInvoice>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringInvoice>();
  }


  /// <summary>
  /// Show recurring invoice
  /// Operation: GET /api/v1/recurring_invoices/{id}
  /// </summary>
  public async Task<ApiResponse<RecurringInvoice>> GetAsync(string id, ShowRecurringInvoiceRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "recurring_invoices/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<RecurringInvoice>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringInvoice>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringInvoice>();
  }


  /// <summary>
  /// Update recurring invoice
  /// Operation: PUT /api/v1/recurring_invoices/{id}
  /// </summary>
  public async Task<ApiResponse<RecurringInvoice>> UpdateAsync(string id, UpdateRecurringInvoiceRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "recurring_invoices/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<RecurringInvoice>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringInvoice>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringInvoice>();
  }


  /// <summary>
  /// Delete recurring invoice
  /// Operation: DELETE /api/v1/recurring_invoices/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeleteRecurringInvoiceRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "recurring_invoices/{id}".BuildUrl(pathParams, request);

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
  /// Edit recurring invoice
  /// Operation: GET /api/v1/recurring_invoices/{id}/edit
  /// </summary>
  public async Task<ApiResponse<RecurringInvoice>> EditRecurringInvoiceAsync(string id, EditRecurringInvoiceRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "recurring_invoices/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<RecurringInvoice>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringInvoice>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringInvoice>();
  }


  /// <summary>
  /// Blank recurring invoice
  /// Operation: GET /api/v1/recurring_invoices/create
  /// </summary>
  public async Task<ApiResponse<RecurringInvoice>> GetRecurringInvoicesCreateAsync(GetRecurringInvoicesCreateRequest? request = null)
  {
    string url = "recurring_invoices/create".BuildUrl(request: request);

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
    ApiResponse<RecurringInvoice>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringInvoice>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringInvoice>();
  }


  /// <summary>
  /// Bulk recurring invoice actions
  /// Operation: POST /api/v1/recurring_invoices/bulk
  /// </summary>
  public async Task<ApiResponse<RecurringInvoice>> BulkAsync(Apigen.InvoiceNinja.Models.BulkRecurringInvoicesRequest bulkRecurringInvoicesRequest, BulkRecurringInvoicesRequest? request = null)
  {
    string url = "recurring_invoices/bulk".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(bulkRecurringInvoicesRequest, JsonConfig.Default);
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
    ApiResponse<RecurringInvoice>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringInvoice>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringInvoice>();
  }


  /// <summary>
  /// Custom recurring invoice action
  /// Operation: GET /api/v1/recurring_invoices/{id}/{action}
  /// </summary>
  public async Task<ApiResponse<RecurringInvoice>> GetAsync(string id, string action, ActionRecurringInvoiceRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["action"] = action
    };
    string url = "recurring_invoices/{id}/{action}".BuildUrl(pathParams, request);

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
    ApiResponse<RecurringInvoice>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringInvoice>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringInvoice>();
  }


  /// <summary>
  /// Download recurring invoice PDF
  /// Operation: GET /api/v1/recurring_invoice/{invitation_key}/download
  /// </summary>
  public async Task<Stream> DownloadRecurringInvoiceAsync(string invitationKey, DownloadRecurringInvoiceRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["invitation_key"] = invitationKey
    };
    string url = "recurring_invoice/{invitation_key}/download".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string errorContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, errorContent, ex);
      throw;
    }
    return await response.Content.ReadAsStreamAsync();
  }


  /// <summary>
  /// Add recurring invoice document
  /// Operation: POST /api/v1/recurring_invoices/{id}/upload
  /// </summary>
  public async Task<ApiResponse<RecurringInvoice>> UploadRecurringInvoiceAsync(string id, Apigen.InvoiceNinja.Models.UploadRecurringInvoiceRequest uploadRecurringInvoiceRequest, UploadRecurringInvoiceRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "recurring_invoices/{id}/upload".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    MultipartFormDataContent content = uploadRecurringInvoiceRequest.ToMultipartContent();
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "multipart/form-data", "[binary content]");
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
    ApiResponse<RecurringInvoice>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringInvoice>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringInvoice>();
  }


}
