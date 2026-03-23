using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for expense_categories operations
/// </summary>
public interface IExpenseCategoriesClient
{
  /// <summary>
  /// Gets a list of expense_categories
  /// Operation: GET /api/v1/expense_categories
  /// </summary>
  Task<ApiResponse<ExpenseCategory[]>> ListAsync(GetExpenseCategorysRequest? request = null);

  /// <summary>
  /// Adds a expense category
  /// Operation: POST /api/v1/expense_categories
  /// </summary>
  Task<ApiResponse<ExpenseCategory>> CreateAsync(StoreExpenseCategoryRequest? request = null);

  /// <summary>
  /// Gets a new blank Expens Category object
  /// Operation: GET /api/v1/expense_categories/create
  /// </summary>
  Task<ApiResponse<ExpenseCategory>> GetExpenseCategoryCreateAsync();

  /// <summary>
  /// Shows a Expens Category
  /// Operation: GET /api/v1/expense_categories/{id}
  /// </summary>
  Task<ApiResponse<ExpenseCategory>> GetAsync(string id);

  /// <summary>
  /// Updates a tax rate
  /// Operation: PUT /api/v1/expense_categories/{id}
  /// </summary>
  Task<ApiResponse<ExpenseCategory>> UpdateAsync(string id);

  /// <summary>
  /// Deletes a ExpenseCategory
  /// Operation: DELETE /api/v1/expense_categories/{id}
  /// </summary>
  Task DeleteAsync(string id);

  /// <summary>
  /// Shows a Expens Category for editting
  /// Operation: GET /api/v1/expense_categories/{id}/edit
  /// </summary>
  Task<ApiResponse<ExpenseCategory>> EditExpenseCategoryAsync(string id);

  /// <summary>
  /// Performs bulk actions on an array of ExpenseCategorys
  /// Operation: POST /api/v1/expense_categories/bulk
  /// </summary>
  Task<ApiResponse<Webhook>> BulkAsync(BulkExpenseCategorysRequest? request = null);

}
