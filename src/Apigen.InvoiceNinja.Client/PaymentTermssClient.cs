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
/// Client for payment_termss operations
/// </summary>
public class PaymentTermssClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal PaymentTermssClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Deletes a Payment Term
  /// Operation: DELETE /api/v1/payment_terms/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeletePaymentTermRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "payment_terms/{id}".BuildUrl(pathParams, request);

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


}
