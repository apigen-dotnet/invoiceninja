using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for company_ledger operations
/// </summary>
public partial interface ICompanyLedgerClient
{
  /// <summary>
  /// Gets a list of company_ledger
  /// Operation: GET /api/v1/company_ledger
  /// </summary>
  Task<ApiResponse<CompanyLedger[]>> ListAsync(GetCompanyLedgerRequest? request = null);

}
