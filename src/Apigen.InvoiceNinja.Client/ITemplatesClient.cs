using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for templates operations
/// </summary>
public interface ITemplatesClient
{
  /// <summary>
  /// Returns a entity template with the template variables replaced with the Entities
  /// Operation: POST /api/v1/templates
  /// </summary>
  Task<ApiResponse<Template>> CreateAsync(Apigen.InvoiceNinja.Models.GetShowTemplateRequest getShowTemplateRequest, GetShowTemplateRequest? request = null);

  /// <summary>
  /// Preview template by hash
  /// Operation: POST /api/v1/templates/preview/{hash}
  /// </summary>
  Task GetTemplatePreviewAsync(string hash);

}
