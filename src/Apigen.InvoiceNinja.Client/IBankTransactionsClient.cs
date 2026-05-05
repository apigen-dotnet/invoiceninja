using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for bank_transactions operations
/// </summary>
public partial interface IBankTransactionsClient
{
  /// <summary>
  /// Gets a list of bank_transactions
  /// Operation: GET /api/v1/bank_transactions
  /// </summary>
  Task<ApiResponse<BankTransaction[]>> ListAsync(GetBankTransactionsRequest? request = null);

  /// <summary>
  /// Adds a bank_transaction
  /// Operation: POST /api/v1/bank_transactions
  /// </summary>
  Task<ApiResponse<BankTransaction>> CreateAsync(StoreBankTransactionRequest? request = null);

  /// <summary>
  /// Shows a bank_transaction
  /// Operation: GET /api/v1/bank_transactions/{id}
  /// </summary>
  Task<ApiResponse<BankTransaction>> GetAsync(string id, ShowBankTransactionRequest? request = null);

  /// <summary>
  /// Updates a bank_transaction
  /// Operation: PUT /api/v1/bank_transactions/{id}
  /// </summary>
  Task<ApiResponse<BankTransaction>> UpdateAsync(string id, UpdateBankTransactionRequest? request = null);

  /// <summary>
  /// Deletes a bank_transaction
  /// Operation: DELETE /api/v1/bank_transactions/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteBankTransactionRequest? request = null);

  /// <summary>
  /// Shows a bank_transaction for editing
  /// Operation: GET /api/v1/bank_transactions/{id}/edit
  /// </summary>
  Task<ApiResponse<BankTransaction>> EditBankTransactionAsync(string id, EditBankTransactionRequest? request = null);

  /// <summary>
  /// Gets a new blank bank_transaction object
  /// Operation: GET /api/v1/bank_transactions/create
  /// </summary>
  Task<ApiResponse<BankTransaction>> GetBankTransactionsCreateAsync(GetBankTransactionsCreateRequest? request = null);

  /// <summary>
  /// Bulk actions
  /// Operation: POST /api/v1/bank_transactions/bulk
  /// </summary>
  Task BulkAsync(BulkBankTransactionsRequest? request = null);

  /// <summary>
  /// Match transactions
  /// Operation: POST /api/v1/bank_transactions/match
  /// </summary>
  Task MatchBankTransactionsAsync(MatchBankTransactionsRequest? request = null);

}
