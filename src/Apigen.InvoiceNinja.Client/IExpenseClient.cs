using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for expense operations
/// </summary>
public partial interface IExpenseClient
{
  /// <summary>
  /// Uploads a document to a expense
  /// Operation: POST /api/v1/expenses/{id}/upload
  /// </summary>
  Task<ApiResponse<Expense>> UploadExpenseAsync(string id, Apigen.InvoiceNinja.Models.UploadExpenseRequest uploadExpenseRequest, UploadExpenseRequest? request = null);

}
