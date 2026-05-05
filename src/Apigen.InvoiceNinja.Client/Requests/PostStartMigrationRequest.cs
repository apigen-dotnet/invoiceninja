using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Request parameters for Starts the migration from previous version of Invoice Ninja
/// Operation: POST /api/v1/migration/start
/// </summary>
public partial class PostStartMigrationRequest : BaseRequest
{
  /// <summary>
  /// The migraton file
  /// </summary>
  [JsonPropertyName("migration")]
  public string? Migration { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    queryParams["_method"] = "POST";

    // Fixed parameters added for POST /api/v1/migration/start
    if (Migration != null)
      queryParams["migration"] = Migration;

    return queryParams.ToQueryString();
  }
}
