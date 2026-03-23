using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for migration operations
/// </summary>
public interface IMigrationClient
{
  /// <summary>
  /// Attempts to purge a company record and all its child records
  /// Operation: POST /api/v1/migration/purge/{company}
  /// </summary>
  Task PostPurgeCompanyAsync(string company);

  /// <summary>
  /// Attempts to purge a companies child records but save the company record and its settings
  /// Operation: POST /api/v1/migration/purge_save_settings/{company}
  /// </summary>
  Task PostPurgeCompanySaveSettingsAsync(string company);

  /// <summary>
  /// Starts the migration from previous version of Invoice Ninja
  /// Operation: POST /api/v1/migration/start
  /// </summary>
  Task PostStartMigrationAsync(PostStartMigrationRequest? request = null);

}
