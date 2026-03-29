using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Apigen.Generator;

/// <summary>
/// Add per_page_meta/page_meta parameter refs to list endpoints that are missing them.
/// </summary>
public class AddPaginationParams : ISpecPatch
{
  public string Name => "Add pagination params to list endpoints";

  private static readonly List<(OperationType Method, string Path)> Endpoints = new()
  {
    (OperationType.Get, "/api/v1/bank_integrations"),
    (OperationType.Get, "/api/v1/bank_transactions"),
    (OperationType.Get, "/api/v1/bank_transaction_rules"),
    (OperationType.Get, "/api/v1/client_gateway_tokens"),
    (OperationType.Get, "/api/v1/companies"),
    (OperationType.Get, "/api/v1/company_gateways"),
    (OperationType.Get, "/api/v1/designs"),
    (OperationType.Get, "/api/v1/documents"),
    (OperationType.Get, "/api/v1/expense_categories"),
    (OperationType.Get, "/api/v1/expenses"),
    (OperationType.Get, "/api/v1/group_settings"),
    (OperationType.Get, "/api/v1/payment_terms"),
    (OperationType.Get, "/api/v1/recurring_expenses"),
    (OperationType.Get, "/api/v1/recurring_quotes"),
    (OperationType.Get, "/api/v1/subscriptions"),
    (OperationType.Get, "/api/v1/system_logs"),
    (OperationType.Get, "/api/v1/task_schedulers/"),
    (OperationType.Get, "/api/v1/task_schedulers/create"),
    (OperationType.Get, "/api/v1/task_statuses"),
    (OperationType.Get, "/api/v1/tax_rates"),
    (OperationType.Get, "/api/v1/tokens"),
    (OperationType.Get, "/api/v1/users"),
    (OperationType.Get, "/api/v1/webhooks"),
    (OperationType.Post, "/api/v1/reports/clients"),
    (OperationType.Post, "/api/v1/reports/contacts"),
    (OperationType.Post, "/api/v1/reports/credit"),
    (OperationType.Post, "/api/v1/reports/documents"),
    (OperationType.Post, "/api/v1/reports/expense"),
    (OperationType.Post, "/api/v1/reports/invoice_items"),
    (OperationType.Post, "/api/v1/reports/invoices"),
    (OperationType.Post, "/api/v1/reports/payments"),
    (OperationType.Post, "/api/v1/reports/product_sales"),
    (OperationType.Post, "/api/v1/reports/products"),
    (OperationType.Post, "/api/v1/reports/profitloss"),
    (OperationType.Post, "/api/v1/reports/quote_items"),
    (OperationType.Post, "/api/v1/reports/quotes"),
    (OperationType.Post, "/api/v1/reports/recurring_invoices"),
    (OperationType.Post, "/api/v1/reports/tasks"),
    (OperationType.Post, "/api/v1/templates"),
  };

  public bool Apply(OpenApiDocument document)
  {
    if (document.Paths == null) return false;

    int count = 0;
    foreach (var (method, path) in Endpoints)
    {
      if (!document.Paths.TryGetValue(path, out OpenApiPathItem? pathItem)) continue;
      if (!pathItem.Operations.TryGetValue(method, out OpenApiOperation? operation)) continue;

      // Check if already has per_page_meta
      bool hasMeta = false;
      foreach (var param in operation.Parameters)
      {
        if (param.Reference?.Id == "per_page_meta")
        {
          hasMeta = true;
          break;
        }
      }
      if (hasMeta) continue;

      // Resolve the parameter definitions from components
      var components = document.Components?.Parameters;
      if (components == null) continue;

      if (components.TryGetValue("per_page_meta", out OpenApiParameter? perPageParam))
      {
        operation.Parameters.Add(perPageParam);
      }
      if (components.TryGetValue("page_meta", out OpenApiParameter? pageParam))
      {
        operation.Parameters.Add(pageParam);
      }
      count++;
    }

    return count > 0;
  }
}
