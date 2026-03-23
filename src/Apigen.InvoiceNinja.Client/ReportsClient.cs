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
/// Client for reports operations
/// </summary>
public class ReportsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ReportsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Contact reports
  /// Operation: POST /api/v1/reports/contacts
  /// </summary>
  public async Task GetContactReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetContactReportRequest? request = null)
  {
    string url = "reports/contacts".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Client reports
  /// Operation: POST /api/v1/reports/clients
  /// </summary>
  public async Task GetClientReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetClientReportRequest? request = null)
  {
    string url = "reports/clients".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Credit reports
  /// Operation: POST /api/v1/reports/credit
  /// </summary>
  public async Task GetCreditReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetCreditReportRequest? request = null)
  {
    string url = "reports/credit".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Document reports
  /// Operation: POST /api/v1/reports/documents
  /// </summary>
  public async Task GetDocumentReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetDocumentReportRequest? request = null)
  {
    string url = "reports/documents".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Expense reports
  /// Operation: POST /api/v1/reports/expense
  /// </summary>
  public async Task GetExpenseReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetExpenseReportRequest? request = null)
  {
    string url = "reports/expense".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Invoice item reports
  /// Operation: POST /api/v1/reports/invoice_items
  /// </summary>
  public async Task GetInvoiceItemReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetInvoiceItemReportRequest? request = null)
  {
    string url = "reports/invoice_items".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Invoice reports
  /// Operation: POST /api/v1/reports/invoices
  /// </summary>
  public async Task GetInvoiceReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetInvoiceReportRequest? request = null)
  {
    string url = "reports/invoices".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Payment reports
  /// Operation: POST /api/v1/reports/payments
  /// </summary>
  public async Task GetPaymentReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetPaymentReportRequest? request = null)
  {
    string url = "reports/payments".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Product reports
  /// Operation: POST /api/v1/reports/products
  /// </summary>
  public async Task GetProductReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetProductReportRequest? request = null)
  {
    string url = "reports/products".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Product Salesreports
  /// Operation: POST /api/v1/reports/product_sales
  /// </summary>
  public async Task GetProductSalesReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetProductSalesReportRequest? request = null)
  {
    string url = "reports/product_sales".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Profit loss reports
  /// Operation: POST /api/v1/reports/profitloss
  /// </summary>
  public async Task GetProfitLossReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetProfitLossReportRequest? request = null)
  {
    string url = "reports/profitloss".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Quote item reports
  /// Operation: POST /api/v1/reports/quote_items
  /// </summary>
  public async Task GetQuoteItemReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetQuoteItemReportRequest? request = null)
  {
    string url = "reports/quote_items".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Quote reports
  /// Operation: POST /api/v1/reports/quotes
  /// </summary>
  public async Task GetQuoteReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetQuoteReportRequest? request = null)
  {
    string url = "reports/quotes".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Recurring Invoice reports
  /// Operation: POST /api/v1/reports/recurring_invoices
  /// </summary>
  public async Task GetRecurringInvoiceReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetRecurringInvoiceReportRequest? request = null)
  {
    string url = "reports/recurring_invoices".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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


  /// <summary>
  /// Task reports
  /// Operation: POST /api/v1/reports/tasks
  /// </summary>
  public async Task GetTaskReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetTaskReportRequest? request = null)
  {
    string url = "reports/tasks".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericReportSchema, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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
