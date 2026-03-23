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
/// Client for payment_terms operations
/// </summary>
public class PaymentTermsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal PaymentTermsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Gets a list of payment terms
  /// Operation: GET /api/v1/payment_terms
  /// </summary>
  public async Task<ApiResponse<PaymentTerm[]>> ListAsync(GetPaymentTermsRequest? request = null)
  {
    string url = "payment_terms".BuildUrl(request: request);

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
    ApiResponse<PaymentTerm[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PaymentTerm[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PaymentTerm[]>();
  }


  /// <summary>
  /// Adds a Payment
  /// Operation: POST /api/v1/payment_terms
  /// </summary>
  public async Task<ApiResponse<PaymentTerm>> CreateAsync(Apigen.InvoiceNinja.Models.PaymentTerm paymentTerm, StorePaymentTermRequest? request = null)
  {
    string url = "payment_terms".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(paymentTerm, JsonConfig.Default);
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
    ApiResponse<PaymentTerm>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PaymentTerm>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PaymentTerm>();
  }


  /// <summary>
  /// Gets a new blank PaymentTerm object
  /// Operation: GET /api/v1/payment_terms/create
  /// </summary>
  public async Task<ApiResponse<Payment>> GetPaymentTermsCreateAsync(GetPaymentTermsCreateRequest? request = null)
  {
    string url = "payment_terms/create".BuildUrl(request: request);

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
  /// Shows a Payment Term
  /// Operation: GET /api/v1/payment_terms/{id}
  /// </summary>
  public async Task<ApiResponse<PaymentTerm>> GetAsync(string id, ShowPaymentTermRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "payment_terms/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<PaymentTerm>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PaymentTerm>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PaymentTerm>();
  }


  /// <summary>
  /// Updates a Payment Term
  /// Operation: PUT /api/v1/payment_terms/{id}
  /// </summary>
  public async Task<ApiResponse<PaymentTerm>> UpdateAsync(string id, UpdatePaymentTermRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "payment_terms/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<PaymentTerm>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PaymentTerm>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PaymentTerm>();
  }


  /// <summary>
  /// Shows an Payment Term for editting
  /// Operation: GET /api/v1/payment_terms/{id}/edit
  /// </summary>
  public async Task<ApiResponse<PaymentTerm>> EditPaymentTermsAsync(string id, EditPaymentTermsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "payment_terms/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<PaymentTerm>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PaymentTerm>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PaymentTerm>();
  }


  /// <summary>
  /// Performs bulk actions on an array of payment terms
  /// Operation: POST /api/v1/payment_terms/bulk
  /// </summary>
  public async Task<ApiResponse<PaymentTerm>> BulkAsync(BulkPaymentTermsRequest? request = null)
  {
    string url = "payment_terms/bulk".BuildUrl(request: request);

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
    ApiResponse<PaymentTerm>? apiResponse = JsonSerializer.Deserialize<ApiResponse<PaymentTerm>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<PaymentTerm>();
  }


}
