using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for users operations
/// </summary>
public partial interface IUsersClient
{
  /// <summary>
  /// Gets a list of users
  /// Operation: GET /api/v1/users
  /// </summary>
  Task<ApiResponse<User[]>> ListAsync(GetUsersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Adds a User
  /// Operation: POST /api/v1/users
  /// </summary>
  Task<ApiResponse<User>> CreateAsync(StoreUserRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets a new blank User object
  /// Operation: GET /api/v1/users/create
  /// </summary>
  Task<ApiResponse<User>> GetUsersCreateAsync(GetUsersCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows an User
  /// Operation: GET /api/v1/users/{id}
  /// </summary>
  Task<ApiResponse<User>> GetAsync(string id, ShowUserRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates an User
  /// Operation: PUT /api/v1/users/{id}
  /// </summary>
  Task<ApiResponse<User>> UpdateAsync(string id, UpdateUserRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes a User
  /// Operation: DELETE /api/v1/users/{id}
  /// </summary>
  Task DeleteAsync(string id, DeleteUserRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shows an User for editting
  /// Operation: GET /api/v1/users/{id}/edit
  /// </summary>
  Task<ApiResponse<User>> EditUserAsync(string id, EditUserRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Performs bulk actions on an array of users
  /// Operation: POST /api/v1/users/bulk
  /// </summary>
  Task<ApiResponse<User>> BulkAsync(BulkUsersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Detach an existing user to a company
  /// Operation: DELETE /api/v1/users/{user}/detach_from_company
  /// </summary>
  Task DetachUserAsync(string user, DetachUserRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Reconfirm an existing user to a company
  /// Operation: POST /api/v1/users/{user}/invite
  /// </summary>
  Task InviteUserAsync(string user, InviteUserRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Reconfirm an existing user to a company
  /// Operation: POST /api/v1/users/{user}/reconfirm
  /// </summary>
  Task InviteUserReconfirmAsync(string user, InviteUserReconfirmRequest? request = null, CancellationToken cancellationToken = default);

}
