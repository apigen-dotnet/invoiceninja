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
/// Client for recurring_expense operations
/// </summary>
public class RecurringExpenseClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal RecurringExpenseClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Uploads a document to a recurring_expense
  /// Operation: POST /api/v1/recurring_expenses/{id}/upload
  /// </summary>
  public async Task<ApiResponse<RecurringExpense>> UploadRecurringExpenseAsync(string id, Apigen.InvoiceNinja.Models.UploadRecurringExpenseRequest uploadRecurringExpenseRequest, UploadRecurringExpenseRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "recurring_expenses/{id}/upload".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    MultipartFormDataContent content = uploadRecurringExpenseRequest.ToMultipartContent();
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
    ApiResponse<RecurringExpense>? apiResponse = JsonSerializer.Deserialize<ApiResponse<RecurringExpense>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<RecurringExpense>();
  }


}
