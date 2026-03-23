using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for emails operations
/// </summary>
public interface IEmailsClient
{
  /// <summary>
  /// Sends an email for an entity
  /// Operation: POST /api/v1/emails
  /// </summary>
  Task<ApiResponse<Template>> CreateAsync(Apigen.InvoiceNinja.Models.SendEmailTemplateRequest sendEmailTemplateRequest);

}
