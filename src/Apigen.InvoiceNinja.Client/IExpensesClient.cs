using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for expenses operations
/// </summary>
public interface IExpensesClient
{
  /// <summary>
  /// Gets a list of expenses
  /// Operation: GET /api/v1/expenses
  /// </summary>
  Task<ApiResponse<Expense[]>> ListAsync(GetExpensesRequest? request = null);

  /// <summary>
  /// Adds an expense
  /// Operation: POST /api/v1/expenses
  /// </summary>
  Task<ApiResponse<Expense>> CreateAsync(StoreExpenseRequest? request = null);

  /// <summary>
  /// Shows a expense
  /// Operation: GET /api/v1/expenses/{id}
  /// </summary>
  Task<ApiResponse<Expense>> GetAsync(string id, ShowExpenseRequest? request = null);

  /// <summary>
  /// Updates a expense
  /// Operation: PUT /api/v1/expenses/{id}
  /// </summary>
  Task<ApiResponse<Expense>> UpdateAsync(string id, UpdateExpenseRequest? request = null);

  /// <summary>
  /// Deletes a expense
  /// Operation: DELETE /api/v1/expenses/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteExpenseRequest? request = null);

  /// <summary>
  /// Shows a expense for editing
  /// Operation: GET /api/v1/expenses/{id}/edit
  /// </summary>
  Task<ApiResponse<Expense>> EditExpenseAsync(string id, EditExpenseRequest? request = null);

  /// <summary>
  /// Gets a new blank expense object
  /// Operation: GET /api/v1/expenses/create
  /// </summary>
  Task<ApiResponse<Expense>> GetExpensesCreateAsync(GetExpensesCreateRequest? request = null);

  /// <summary>
  /// Performs bulk actions on an array of expenses
  /// Operation: POST /api/v1/expenses/bulk
  /// </summary>
  Task<ApiResponse<Expense>> BulkAsync(BulkExpensesRequest? request = null);

}
