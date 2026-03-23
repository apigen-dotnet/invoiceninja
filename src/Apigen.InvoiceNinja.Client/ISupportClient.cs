using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for support operations
/// </summary>
public interface ISupportClient
{
  /// <summary>
  /// Sends a support message to Invoice Ninja team
  /// Operation: POST /api/v1/support/messages/send
  /// </summary>
  Task<ApiResponse<JsonElement>> SupportMessageAsync(Apigen.InvoiceNinja.Models.SupportMessageRequest supportMessageRequest);

}
