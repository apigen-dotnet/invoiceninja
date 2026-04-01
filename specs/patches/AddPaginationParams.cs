using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi;
using Apigen.Generator;

/// <summary>
/// Add per_page_meta/page_meta parameter refs to list endpoints that are missing them.
/// </summary>
public class AddPaginationParams : ISpecPatch
{
  public string Name => "Add pagination params to list endpoints";

  // Use string method names to avoid dependency on System.Net.Http assembly
  private static readonly List<(string Method, string Path)> Endpoints = new()
  {
    ("GET", "/api/v1/bank_integrations"),
    ("GET", "/api/v1/bank_transactions"),
    ("GET", "/api/v1/bank_transaction_rules"),
    ("GET", "/api/v1/client_gateway_tokens"),
    ("GET", "/api/v1/companies"),
    ("GET", "/api/v1/company_gateways"),
    ("GET", "/api/v1/designs"),
    ("GET", "/api/v1/documents"),
    ("GET", "/api/v1/expense_categories"),
    ("GET", "/api/v1/expenses"),
    ("GET", "/api/v1/group_settings"),
    ("GET", "/api/v1/payment_terms"),
    ("GET", "/api/v1/recurring_expenses"),
    ("GET", "/api/v1/recurring_quotes"),
    ("GET", "/api/v1/subscriptions"),
    ("GET", "/api/v1/system_logs"),
    ("GET", "/api/v1/task_schedulers/"),
    ("GET", "/api/v1/task_schedulers/create"),
    ("GET", "/api/v1/task_statuses"),
    ("GET", "/api/v1/tax_rates"),
    ("GET", "/api/v1/tokens"),
    ("GET", "/api/v1/users"),
    ("GET", "/api/v1/webhooks"),
    ("POST", "/api/v1/reports/clients"),
    ("POST", "/api/v1/reports/contacts"),
    ("POST", "/api/v1/reports/credit"),
    ("POST", "/api/v1/reports/documents"),
    ("POST", "/api/v1/reports/expense"),
    ("POST", "/api/v1/reports/invoice_items"),
    ("POST", "/api/v1/reports/invoices"),
    ("POST", "/api/v1/reports/payments"),
    ("POST", "/api/v1/reports/product_sales"),
    ("POST", "/api/v1/reports/products"),
    ("POST", "/api/v1/reports/profitloss"),
    ("POST", "/api/v1/reports/quote_items"),
    ("POST", "/api/v1/reports/quotes"),
    ("POST", "/api/v1/reports/recurring_invoices"),
    ("POST", "/api/v1/reports/tasks"),
    ("POST", "/api/v1/templates"),
  };

  public bool Apply(OpenApiDocument document)
  {
    if (document.Paths == null) return false;

    int count = 0;
    foreach (var (methodStr, path) in Endpoints)
    {
      if (!document.Paths.TryGetValue(path, out IOpenApiPathItem? iPathItem)) continue;
      if (iPathItem is not OpenApiPathItem pathItem) continue;
      if (pathItem.Operations == null) continue;

      // In 3.x, Operations is keyed by System.Net.Http.HttpMethod
      var httpMethod = new System.Net.Http.HttpMethod(methodStr);
      if (!pathItem.Operations.TryGetValue(httpMethod, out OpenApiOperation? operation)) continue;

      // Check if already has per_page_meta
      bool hasMeta = false;
      if (operation.Parameters != null)
      {
        foreach (var param in operation.Parameters)
        {
          if (param is OpenApiParameterReference paramRef && paramRef.Reference?.Id == "per_page_meta")
          {
            hasMeta = true;
            break;
          }
          // Also check by name for non-reference parameters
          if (param.Name == "per_page_meta")
          {
            hasMeta = true;
            break;
          }
        }
      }
      if (hasMeta) continue;

      // Resolve the parameter definitions from components
      var components = document.Components?.Parameters;
      if (components == null) continue;

      // In 3.x, add parameter references instead of resolved parameters
      if (components.ContainsKey("per_page_meta"))
      {
        operation.Parameters ??= new List<IOpenApiParameter>();
        operation.Parameters.Add(new OpenApiParameterReference("per_page_meta", document));
      }
      if (components.ContainsKey("page_meta"))
      {
        operation.Parameters ??= new List<IOpenApiParameter>();
        operation.Parameters.Add(new OpenApiParameterReference("page_meta", document));
      }
      count++;
    }

    return count > 0;
  }
}
