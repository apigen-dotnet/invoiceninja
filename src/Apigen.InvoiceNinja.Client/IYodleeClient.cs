using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for yodlee operations
/// </summary>
public partial interface IYodleeClient
{
  /// <summary>
  /// Yodlee Webhook
  /// Operation: POST /api/v1/yodlee/refresh
  /// </summary>
  Task<ApiResponse<Credit>> YodleeRefreshWebhookAsync();

}
