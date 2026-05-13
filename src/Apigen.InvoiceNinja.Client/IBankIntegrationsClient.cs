using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for bank_integrations operations
/// </summary>
public partial interface IBankIntegrationsClient
{
  /// <summary>
  /// Returns a list of Bank Integrations
  /// Operation: GET /api/v1/bank_integrations
  /// </summary>
  Task<ApiResponse<BankIntegration[]>> ListAsync(GetBankIntegrationsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Adds a bank_integration
  /// Operation: POST /api/v1/bank_integrations
  /// </summary>
  Task<ApiResponse<BankIntegration>> CreateAsync(StoreBankIntegrationRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows a bank_integration
  /// Operation: GET /api/v1/bank_integrations/{id}
  /// </summary>
  Task<ApiResponse<BankIntegration>> GetAsync(string id, ShowBankIntegrationRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates a bank_integration
  /// Operation: PUT /api/v1/bank_integrations/{id}
  /// </summary>
  Task<ApiResponse<BankIntegration>> UpdateAsync(string id, UpdateBankIntegrationRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes a bank_integration
  /// Operation: DELETE /api/v1/bank_integrations/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteBankIntegrationRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows a bank_integration for editing
  /// Operation: GET /api/v1/bank_integrations/{id}/edit
  /// </summary>
  Task<ApiResponse<BankIntegration>> EditBankIntegrationAsync(string id, EditBankIntegrationRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets a new blank bank_integration object
  /// Operation: GET /api/v1/bank_integrations/create
  /// </summary>
  Task<ApiResponse<BankIntegration>> GetBankIntegrationsCreateAsync(GetBankIntegrationsCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Performs bulk actions on an array of bank_integrations
  /// Operation: POST /api/v1/bank_integrations/bulk
  /// </summary>
  Task BulkAsync(BulkBankIntegrationsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets the list of accounts from the remote server
  /// Operation: POST /api/v1/bank_integrations/refresh_accounts
  /// </summary>
  Task<ApiResponse<BankIntegration>> GetRefreshAccountsAsync(GetRefreshAccountsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Removes an account from the integration
  /// Operation: POST /api/v1/bank_integrations/remove_account/account_id
  /// </summary>
  Task<ApiResponse<BankIntegration>> GetRemoveAccountAsync(GetRemoveAccountRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Retrieve transactions for a account
  /// Operation: POST /api/v1/bank_integrations/get_transactions/account_id
  /// </summary>
  Task<ApiResponse<BankIntegration>> GetAccountTransactionsAsync(GetAccountTransactionsRequest? request = null, CancellationToken cancellationToken = default);

}
