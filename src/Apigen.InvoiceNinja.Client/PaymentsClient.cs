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
/// Client for payments operations
/// </summary>
public class PaymentsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal PaymentsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// List payments
  /// Operation: GET /api/v1/payments
  /// </summary>
  public async Task<ApiResponse<Payment[]>> ListAsync(GetPaymentsRequest? request = null)
  {
    string url = "payments".BuildUrl(request: request);

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
    ApiResponse<Payment[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Payment[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Payment[]>();
  }


  /// <summary>
  /// Create payment
  /// Operation: POST /api/v1/payments
  /// </summary>
  public async Task<ApiResponse<Payment>> CreateAsync(Apigen.InvoiceNinja.Models.PaymentRequest paymentRequest, StorePaymentRequest? request = null)
  {
    string url = "payments".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(paymentRequest, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
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
    ApiResponse<Payment>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Payment>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Payment>();
  }


  /// <summary>
  /// Show payment
  /// Operation: GET /api/v1/payments/{id}
  /// </summary>
  public async Task<ApiResponse<Payment>> GetAsync(string id, ShowPaymentRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "payments/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<Payment>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Payment>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Payment>();
  }


  /// <summary>
  /// Update payment
  /// Operation: PUT /api/v1/payments/{id}
  /// </summary>
  public async Task<ApiResponse<Payment>> UpdateAsync(string id, UpdatePaymentRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "payments/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<Payment>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Payment>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Payment>();
  }


  /// <summary>
  /// Delete payment
  /// Operation: DELETE /api/v1/payments/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeletePaymentRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "payments/{id}".BuildUrl(pathParams, request);

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
  /// Edit payment
  /// Operation: GET /api/v1/payments/{id}/edit
  /// </summary>
  public async Task<ApiResponse<Payment>> EditPaymentAsync(string id, EditPaymentRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "payments/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<Payment>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Payment>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Payment>();
  }


  /// <summary>
  /// Blank payment
  /// Operation: GET /api/v1/payments/create
  /// </summary>
  public async Task<ApiResponse<Payment>> GetPaymentsCreateAsync(GetPaymentsCreateRequest? request = null)
  {
    string url = "payments/create".BuildUrl(request: request);

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
    ApiResponse<Payment>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Payment>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Payment>();
  }


  /// <summary>
  /// Refund payment
  /// Operation: POST /api/v1/payments/refund
  /// </summary>
  public async Task<ApiResponse<Payment>> StoreRefundAsync(Apigen.InvoiceNinja.Models.PaymentRequest payment, StoreRefundRequest? request = null)
  {
    string url = "payments/refund".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(payment, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
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
    ApiResponse<Payment>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Payment>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Payment>();
  }


  /// <summary>
  /// Bulk payment actions
  /// Operation: POST /api/v1/payments/bulk
  /// </summary>
  public async Task<ApiResponse<Payment>> BulkAsync(BulkPaymentsRequest? request = null)
  {
    string url = "payments/bulk".BuildUrl(request: request);

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
    ApiResponse<Payment>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Payment>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Payment>();
  }


  /// <summary>
  /// Custom payment actions
  /// Operation: GET /api/v1/payments/{id}/{action}
  /// </summary>
  public async Task<ApiResponse<Payment>> GetAsync(string id, string action, ActionPaymentRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["action"] = action
    };
    string url = "payments/{id}/{action}".BuildUrl(pathParams, request);

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
    ApiResponse<Payment>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Payment>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Payment>();
  }


  /// <summary>
  /// Upload a payment document
  /// Operation: POST /api/v1/payments/{id}/upload
  /// </summary>
  public async Task<ApiResponse<Payment>> UploadPaymentAsync(string id, Apigen.InvoiceNinja.Models.UploadPaymentRequest uploadPaymentRequest, UploadPaymentRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "payments/{id}/upload".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    MultipartFormDataContent content = uploadPaymentRequest.ToMultipartContent();
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
    ApiResponse<Payment>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Payment>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Payment>();
  }


}
