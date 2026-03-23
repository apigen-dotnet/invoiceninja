using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for bank_transaction_rules operations
/// </summary>
public interface IBankTransactionRulesClient
{
  /// <summary>
  /// Gets a list of bank_transaction_rules
  /// Operation: GET /api/v1/bank_transaction_rules
  /// </summary>
  Task<ApiResponse<BankTransactionRule[]>> ListAsync(GetBankTransactionRulesRequest? request = null);

  /// <summary>
  /// Adds a bank_transaction rule
  /// Operation: POST /api/v1/bank_transaction_rules
  /// </summary>
  Task<ApiResponse<BankTransactionRule>> CreateAsync(StoreBankTransactionRuleRequest? request = null);

  /// <summary>
  /// Shows a bank_transaction
  /// Operation: GET /api/v1/bank_transaction_rules/{id}
  /// </summary>
  Task<ApiResponse<BankTransactionRule>> GetAsync(string id, ShowBankTransactionRuleRequest? request = null);

  /// <summary>
  /// Updates a bank_transaction Rule
  /// Operation: PUT /api/v1/bank_transaction_rules/{id}
  /// </summary>
  Task<ApiResponse<BankTransactionRule>> UpdateAsync(string id, UpdateBankTransactionRuleRequest? request = null);

  /// <summary>
  /// Deletes a bank_transaction rule
  /// Operation: DELETE /api/v1/bank_transaction_rules/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteBankTransactionRuleRequest? request = null);

  /// <summary>
  /// Shows a bank_transaction for editing
  /// Operation: GET /api/v1/bank_transaction_rules/{id}/edit
  /// </summary>
  Task<ApiResponse<BankTransactionRule>> EditBankTransactionRuleAsync(string id, EditBankTransactionRuleRequest? request = null);

  /// <summary>
  /// Gets a new blank bank_transaction rule object
  /// Operation: GET /api/v1/bank_transaction_rules/create
  /// </summary>
  Task<ApiResponse<BankTransactionRule>> GetBankTransactionRulesCreateAsync(GetBankTransactionRulesCreateRequest? request = null);

  /// <summary>
  /// Performs bulk actions on an array of bank_transation rules
  /// Operation: POST /api/v1/bank_transation_rules/bulk
  /// </summary>
  Task BulkAsync(BulkBankTransactionRulesRequest? request = null);

}
