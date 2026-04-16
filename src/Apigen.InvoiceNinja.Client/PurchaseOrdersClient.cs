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
/// Client for Purchase Orders operations
/// </summary>
public class PurchaseOrdersClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal PurchaseOrdersClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// List purchase orders
  /// Operation: GET /api/v1/purchase_orders
  /// </summary>
  public async Task<ApiResponse<PurchaseOrder[]>> GetPurchaseOrdersAsync(GetPurchaseOrdersRequest? request = null)
  {
    string url = "purchase_orders".BuildUrl(request: request);

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
    ApiResponse<PurchaseOrder[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PurchaseOrder[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PurchaseOrder[]>();
  }


  /// <summary>
  /// Create purchase order
  /// Operation: POST /api/v1/purchase_orders
  /// </summary>
  public async Task<ApiResponse<PurchaseOrder>> StorePurchaseOrderAsync(Apigen.InvoiceNinja.Models.PurchaseOrderRequest purchaseOrderRequest, StorePurchaseOrderRequest? request = null)
  {
    string url = "purchase_orders".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(purchaseOrderRequest, JsonConfig.Default);
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
    ApiResponse<PurchaseOrder>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PurchaseOrder>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PurchaseOrder>();
  }


  /// <summary>
  /// Show purchase order
  /// Operation: GET /api/v1/purchase_orders/{id}
  /// </summary>
  public async Task<ApiResponse<PurchaseOrder>> GetAsync(string id, ShowPurchaseOrderRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "purchase_orders/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<PurchaseOrder>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PurchaseOrder>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PurchaseOrder>();
  }


  /// <summary>
  /// Update purchase order
  /// Operation: PUT /api/v1/purchase_order/{id}
  /// </summary>
  public async Task<ApiResponse<PurchaseOrder>> UpdateAsync(string id, Apigen.InvoiceNinja.Models.PurchaseOrderRequest purchaseOrderRequest, UpdatePurchaseOrderRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "purchase_order/{id}".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(purchaseOrderRequest, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "PUT", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PutAsync(url, content);
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
    ApiResponse<PurchaseOrder>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PurchaseOrder>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PurchaseOrder>();
  }


  /// <summary>
  /// Delete purchase order
  /// Operation: DELETE /api/v1/purchase_order/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeletePurchaseOrderRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "purchase_order/{id}".BuildUrl(pathParams, request);

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
  /// Edit purchase order
  /// Operation: GET /api/v1/purchase_orders/{id}/edit
  /// </summary>
  public async Task<ApiResponse<PurchaseOrder>> EditPurchaseOrderAsync(string id, EditPurchaseOrderRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "purchase_orders/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<PurchaseOrder>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PurchaseOrder>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PurchaseOrder>();
  }


  /// <summary>
  /// Blank purchase order
  /// Operation: GET /api/v1/purchase_orders/create
  /// </summary>
  public async Task<ApiResponse<PurchaseOrder>> GetPurchaseOrderCreateAsync(GetPurchaseOrderCreateRequest? request = null)
  {
    string url = "purchase_orders/create".BuildUrl(request: request);

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
    ApiResponse<PurchaseOrder>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PurchaseOrder>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PurchaseOrder>();
  }


  /// <summary>
  /// Bulk purchase order action
  /// Operation: POST /api/v1/purchase_orders/bulk
  /// </summary>
  public async Task BulkAsync(BulkPurchaseOrderssRequest? request = null)
  {
    string url = "purchase_orders/bulk".BuildUrl(request: request);

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
  /// Custom purchase order actions
  /// Operation: GET /api/v1/purchase_orders/{id}/{action}
  /// </summary>
  public async Task<ApiResponse<PurchaseOrder>> GetAsync(string id, string action, ActionPurchaseOrderRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["action"] = action
    };
    string url = "purchase_orders/{id}/{action}".BuildUrl(pathParams, request);

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
    ApiResponse<PurchaseOrder>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PurchaseOrder>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PurchaseOrder>();
  }


  /// <summary>
  /// Uploads a purchase order document
  /// Operation: POST /api/v1/purchase_orders/{id}/upload
  /// </summary>
  public async Task<ApiResponse<PurchaseOrder>> UploadPurchaseOrderAsync(string id, Apigen.InvoiceNinja.Models.UploadPurchaseOrderRequest uploadPurchaseOrderRequest, UploadPurchaseOrderRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "purchase_orders/{id}/upload".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    MultipartFormDataContent content = uploadPurchaseOrderRequest.ToMultipartContent();
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
    ApiResponse<PurchaseOrder>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PurchaseOrder>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PurchaseOrder>();
  }


  /// <summary>
  /// Download a purchase order PDF
  /// Operation: GET /api/v1/purchase_order/{invitation_key}/download
  /// </summary>
  public async Task<Stream> DownloadPurchaseOrderAsync(string invitationKey, DownloadPurchaseOrderRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["invitation_key"] = invitationKey
    };
    string url = "purchase_order/{invitation_key}/download".BuildUrl(pathParams, request);

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


}
