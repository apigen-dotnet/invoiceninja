using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for tax_rates operations
/// </summary>
public interface ITaxRatesClient
{
  /// <summary>
  /// Gets a list of tax_rates
  /// Operation: GET /api/v1/tax_rates
  /// </summary>
  Task<ApiResponse<TaxRate[]>> ListAsync(GetTaxRatesRequest? request = null);

  /// <summary>
  /// Gets a new blank Tax Rate object
  /// Operation: GET /api/v1/tax_rates/create
  /// </summary>
  Task<ApiResponse<TaxRate>> GetTaxRateCreateAsync();

  /// <summary>
  /// Shows a Tax Rate
  /// Operation: GET /api/v1/tax_rates/{id}
  /// </summary>
  Task<ApiResponse<TaxRate>> GetAsync(string id);

  /// <summary>
  /// Updates a tax rate
  /// Operation: PUT /api/v1/tax_rates/{id}
  /// </summary>
  Task<ApiResponse<TaxRate>> UpdateAsync(string id);

  /// <summary>
  /// Deletes a TaxRate
  /// Operation: DELETE /api/v1/tax_rates/{id}
  /// </summary>
  Task DeleteAsync(string id);

  /// <summary>
  /// Shows a Tax Rate for editting
  /// Operation: GET /api/v1/tax_rates/{id}/edit
  /// </summary>
  Task<ApiResponse<TaxRate>> EditTaxRateAsync(string id);

  /// <summary>
  /// Performs bulk actions on an array of TaxRates
  /// Operation: POST /api/v1/tax_rates/bulk
  /// </summary>
  Task<ApiResponse<Webhook>> BulkAsync(BulkTaxRatesRequest? request = null);

}
