using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for preview operations
/// </summary>
public partial interface IPreviewClient
{
  /// <summary>
  /// Returns a pdf preview
  /// Operation: POST /api/v1/preview
  /// </summary>
  Task CreateAsync();

  /// <summary>
  /// Returns a pdf preview for purchase order
  /// Operation: POST /api/v1/preview/purchase_order
  /// </summary>
  Task GetPreviewPurchaseOrderAsync();

}
