using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for group_settings operations
/// </summary>
public partial interface IGroupSettingsClient
{
  /// <summary>
  /// Gets a list of group_settings
  /// Operation: GET /api/v1/group_settings
  /// </summary>
  Task<ApiResponse<GroupSetting[]>> ListAsync(GetGroupSettingsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Adds a GroupSetting
  /// Operation: POST /api/v1/group_settings
  /// </summary>
  Task<ApiResponse<GroupSetting>> CreateAsync(StoreGroupSettingRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets a new blank GroupSetting object
  /// Operation: GET /api/v1/group_settings/create
  /// </summary>
  Task<ApiResponse<GroupSetting>> GetGroupSettingsCreateAsync(GetGroupSettingsCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows an GroupSetting
  /// Operation: GET /api/v1/group_settings/{id}
  /// </summary>
  Task<ApiResponse<GroupSetting>> GetAsync(string id, ShowGroupSettingRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates an GroupSetting
  /// Operation: PUT /api/v1/group_settings/{id}
  /// </summary>
  Task<ApiResponse<GroupSetting>> UpdateAsync(string id, UpdateGroupSettingRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes a GroupSetting
  /// Operation: DELETE /api/v1/group_settings/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteGroupSettingRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows an GroupSetting for editting
  /// Operation: GET /api/v1/group_settings/{id}/edit
  /// </summary>
  Task<ApiResponse<GroupSetting>> EditGroupSettingAsync(string id, EditGroupSettingRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Performs bulk actions on an array of group_settings
  /// Operation: POST /api/v1/group_settings/bulk
  /// </summary>
  Task BulkAsync(BulkGroupSettingsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Uploads a document to a group setting
  /// Operation: POST /api/v1/group_settings/{id}/upload
  /// </summary>
  Task<ApiResponse<Invoice>> UploadGroupSettingAsync(string id, Apigen.InvoiceNinja.Models.UploadGroupSettingRequest uploadGroupSettingRequest, UploadGroupSettingRequest? request = null, CancellationToken cancellationToken = default);

}
