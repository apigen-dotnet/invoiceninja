using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for postmark operations
/// </summary>
public interface IPostmarkClient
{
  /// <summary>
  /// Processing webhooks from Apple for in app purchases
  /// Operation: POST /api/v1/apple/confirm_purchase
  /// </summary>
  Task ConfirmApplePurchaseAsync(ConfirmApplePurchaseRequest? request = null);

  /// <summary>
  /// Processing event webhooks from Apple for in purchase / subscription status update
  /// Operation: POST /api/v1/apple/process_webhook
  /// </summary>
  Task ProcessAppleWebhookAsync(ProcessAppleWebhookRequest? request = null);

  /// <summary>
  /// Processing webhooks from PostMark
  /// Operation: POST /api/v1/postmark_webhook
  /// </summary>
  Task<ApiResponse<Credit>> PostmarkWebhookAsync(PostmarkWebhookRequest? request = null);

}
