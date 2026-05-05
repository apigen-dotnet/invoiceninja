using System.Text.Json.Serialization;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Standard API response wrapper
/// </summary>
public partial class ApiResponse<T>
{
  [JsonPropertyName("data")]
  public T Data { get; set; } = default!;
  [JsonPropertyName("meta")]
  public Apigen.InvoiceNinja.Models.Meta? Meta { get; set; }
}
