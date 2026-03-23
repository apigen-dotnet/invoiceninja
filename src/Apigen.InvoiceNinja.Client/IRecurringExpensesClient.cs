using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for recurring_expenses operations
/// </summary>
public interface IRecurringExpensesClient
{
  /// <summary>
  /// Gets a list of recurring_expenses
  /// Operation: GET /api/v1/recurring_expenses
  /// </summary>
  Task<ApiResponse<RecurringExpense[]>> ListAsync(GetRecurringExpensesRequest? request = null);

  /// <summary>
  /// Adds a recurring expense
  /// Operation: POST /api/v1/recurring_expenses
  /// </summary>
  Task<ApiResponse<RecurringExpense>> CreateAsync(StoreRecurringExpenseRequest? request = null);

  /// <summary>
  /// Shows a recurring expense
  /// Operation: GET /api/v1/recurring_expenses/{id}
  /// </summary>
  Task<ApiResponse<RecurringExpense>> GetAsync(string id, ShowRecurringExpenseRequest? request = null);

  /// <summary>
  /// Updates a recurring expense
  /// Operation: PUT /api/v1/recurring_expenses/{id}
  /// </summary>
  Task<ApiResponse<RecurringExpense>> UpdateAsync(string id, UpdateRecurringExpenseRequest? request = null);

  /// <summary>
  /// Deletes a recurring expense
  /// Operation: DELETE /api/v1/recurring_expenses/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteRecurringExpenseRequest? request = null);

  /// <summary>
  /// Shows a recurring expense for editting
  /// Operation: GET /api/v1/recurring_expenses/{id}/edit
  /// </summary>
  Task<ApiResponse<RecurringExpense>> EditRecurringExpenseAsync(string id, EditRecurringExpenseRequest? request = null);

  /// <summary>
  /// Gets a new blank recurring expense object
  /// Operation: GET /api/v1/recurring_expenses/create
  /// </summary>
  Task<ApiResponse<RecurringExpense>> GetRecurringExpensesCreateAsync(GetRecurringExpensesCreateRequest? request = null);

  /// <summary>
  /// Performs bulk actions on an array of recurring_expenses
  /// Operation: POST /api/v1/recurring_expenses/bulk
  /// </summary>
  Task<ApiResponse<RecurringExpense>> BulkAsync(BulkRecurringExpensesRequest? request = null);

}
