using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for payment_termss operations
/// </summary>
public partial interface IPaymentTermssClient
{
  /// <summary>
  /// Deletes a Payment Term
  /// Operation: DELETE /api/v1/payment_terms/{id}
  /// </summary>
  Task DeleteAsync(string id, DeletePaymentTermRequest? request = null);

}
