using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for company_user operations
/// </summary>
public partial interface ICompanyUserClient
{
  /// <summary>
  /// Update a company user record
  /// Operation: POST /api/v1/company_users
  /// </summary>
  Task<ApiResponse<CompanyUser>> UpdateCompanyUserAsync();

}
