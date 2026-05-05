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
/// Client for clients operations
/// </summary>
public partial class ClientsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ClientsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// List clients
  /// 
  /// Operation: GET /api/v1/clients
  /// </summary>
  public async Task<ApiResponse<Apigen.InvoiceNinja.Models.Client[]>> ListAsync(GetClientsRequest? request = null)
  {
    string url = "clients".BuildUrl(request: request);

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
    ApiResponse<Apigen.InvoiceNinja.Models.Client[]>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Apigen.InvoiceNinja.Models.Client[]>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Apigen.InvoiceNinja.Models.Client[]>();
  }


  /// <summary>
  /// Create client
  /// Operation: POST /api/v1/clients
  /// </summary>
  public async Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> CreateAsync(Apigen.InvoiceNinja.Models.ClientRequest clientRequest, StoreClientRequest? request = null)
  {
    string url = "clients".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(clientRequest, JsonConfig.Default);
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
    ApiResponse<Apigen.InvoiceNinja.Models.Client>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Apigen.InvoiceNinja.Models.Client>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Apigen.InvoiceNinja.Models.Client>();
  }


  /// <summary>
  /// Show client
  /// Operation: GET /api/v1/clients/{id}
  /// </summary>
  public async Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> GetAsync(string id, ShowClientRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "clients/{id}".BuildUrl(pathParams, request);

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
    ApiResponse<Apigen.InvoiceNinja.Models.Client>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Apigen.InvoiceNinja.Models.Client>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Apigen.InvoiceNinja.Models.Client>();
  }


  /// <summary>
  /// Update client
  /// Operation: PUT /api/v1/clients/{id}
  /// </summary>
  public async Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> UpdateAsync(string id, Apigen.InvoiceNinja.Models.ClientRequest clientRequest, UpdateClientRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "clients/{id}".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(clientRequest, JsonConfig.Default);
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
    ApiResponse<Apigen.InvoiceNinja.Models.Client>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Apigen.InvoiceNinja.Models.Client>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Apigen.InvoiceNinja.Models.Client>();
  }


  /// <summary>
  /// Delete client
  /// Operation: DELETE /api/v1/clients/{id}
  /// </summary>
  public async Task DeleteAsync(string id, DeleteClientRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "clients/{id}".BuildUrl(pathParams, request);

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
  /// Edit Client
  /// Operation: GET /api/v1/clients/{id}/edit
  /// </summary>
  public async Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> EditClientAsync(string id, EditClientRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "clients/{id}/edit".BuildUrl(pathParams, request);

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
    ApiResponse<Apigen.InvoiceNinja.Models.Client>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Apigen.InvoiceNinja.Models.Client>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Apigen.InvoiceNinja.Models.Client>();
  }


  /// <summary>
  /// Blank Client
  /// Operation: GET /api/v1/clients/create
  /// </summary>
  public async Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> GetClientsCreateAsync(GetClientsCreateRequest? request = null)
  {
    string url = "clients/create".BuildUrl(request: request);

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
    ApiResponse<Apigen.InvoiceNinja.Models.Client>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Apigen.InvoiceNinja.Models.Client>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Apigen.InvoiceNinja.Models.Client>();
  }


  /// <summary>
  /// Bulk client actions
  /// Operation: POST /api/v1/clients/bulk
  /// </summary>
  public async Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> BulkAsync(Apigen.InvoiceNinja.Models.GenericBulkAction genericBulkAction, BulkClientsRequest? request = null)
  {
    string url = "clients/bulk".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(genericBulkAction, JsonConfig.Default);
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
    ApiResponse<Apigen.InvoiceNinja.Models.Client>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Apigen.InvoiceNinja.Models.Client>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Apigen.InvoiceNinja.Models.Client>();
  }


  /// <summary>
  /// Add client document
  /// Operation: POST /api/v1/clients/{id}/upload
  /// </summary>
  public async Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> UploadClientAsync(string id, Apigen.InvoiceNinja.Models.UploadClientRequest uploadClientRequest, UploadClientRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "clients/{id}/upload".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    MultipartFormDataContent content = uploadClientRequest.ToMultipartContent();
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
    ApiResponse<Apigen.InvoiceNinja.Models.Client>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Apigen.InvoiceNinja.Models.Client>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Apigen.InvoiceNinja.Models.Client>();
  }


  /// <summary>
  /// Purge client
  /// Operation: POST /api/v1/clients/{id}/purge
  /// </summary>
  public async Task PurgeClientAsync(string id)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "clients/{id}/purge".BuildUrl(pathParams);

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
  /// Merge client
  /// Operation: POST /api/v1/clients/{id}/{mergeable_client_hashed_id}/merge
  /// </summary>
  public async Task MergeClientAsync(string id, string mergeableClientHashedId, MergeClientRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["mergeable_client_hashed_id"] = mergeableClientHashedId
    };
    string url = "clients/{id}/{mergeable_client_hashed_id}/merge".BuildUrl(pathParams, request);

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
  /// Client statement PDF
  /// Operation: POST /api/v1/client_statement
  /// </summary>
  public async Task<ApiResponse<Apigen.InvoiceNinja.Models.Client>> ClientStatementAsync(Apigen.InvoiceNinja.Models.ClientStatementRequest clientStatementRequest, ClientStatementRequest? request = null)
  {
    string url = "client_statement".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(clientStatementRequest, JsonConfig.Default);
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
    ApiResponse<Apigen.InvoiceNinja.Models.Client>? apiResponse = JsonSerializer.Deserialize<ApiResponse<Apigen.InvoiceNinja.Models.Client>>(responseContent, JsonConfig.Default);
    return apiResponse ?? new ApiResponse<Apigen.InvoiceNinja.Models.Client>();
  }


  /// <summary>
  /// Removes email suppression of a user in the system
  /// Operation: POST /api/v1/reactivate_email/{bounce_id}
  /// </summary>
  public async Task ReactivateEmailAsync(string bounceId, ReactivateEmailRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["bounce_id"] = bounceId
    };
    string url = "reactivate_email/{bounce_id}".BuildUrl(pathParams, request);

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
  /// Update tax data
  /// Operation: POST /api/v1/clients/{client}/updateTaxData
  /// </summary>
  public async Task UpdateClientTaxDataAsync(string client, UpdateClientTaxDataRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["client"] = client
    };
    string url = "clients/{client}/updateTaxData".BuildUrl(pathParams, request);

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


}
