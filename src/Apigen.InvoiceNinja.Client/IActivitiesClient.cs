using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for activities operations
/// </summary>
public interface IActivitiesClient
{
  /// <summary>
  /// Returns a list of activities
  /// Operation: GET /api/v1/activities
  /// </summary>
  Task<ApiResponse<Activity[]>> ListAsync(GetActivitiesRequest? request = null);

  /// <summary>
  /// Returns a PDF for the given activity
  /// Operation: GET /api/v1/activities/download_entity/{activity_id}
  /// </summary>
  Task<Stream> GetAsync(string activityId, GetActivityHistoricalEntityPdfRequest? request = null);

  /// <summary>
  /// Entity activity
  /// Operation: POST /api/v1/activities/entity
  /// </summary>
  Task PostActivitiesEntityAsync();

  /// <summary>
  /// Activity note
  /// Operation: POST /api/v1/activities/notes
  /// </summary>
  Task PostActivitiesNotesAsync();

}
