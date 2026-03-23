using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for recurring_expense operations
/// </summary>
public interface IRecurringExpenseClient
{
  /// <summary>
  /// Uploads a document to a recurring_expense
  /// Operation: POST /api/v1/recurring_expenses/{id}/upload
  /// </summary>
  Task<ApiResponse<RecurringExpense>> UploadRecurringExpenseAsync(string id, Apigen.InvoiceNinja.Models.UploadRecurringExpenseRequest uploadRecurringExpenseRequest, UploadRecurringExpenseRequest? request = null);

}
