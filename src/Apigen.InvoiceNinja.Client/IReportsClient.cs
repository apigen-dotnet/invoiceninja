using System.Text.Json;
using System.Threading.Tasks;
using Apigen.InvoiceNinja.Models;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Interface for reports operations
/// </summary>
public interface IReportsClient
{
  /// <summary>
  /// Contact reports
  /// Operation: POST /api/v1/reports/contacts
  /// </summary>
  Task GetContactReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Client reports
  /// Operation: POST /api/v1/reports/clients
  /// </summary>
  Task GetClientReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Credit reports
  /// Operation: POST /api/v1/reports/credits
  /// </summary>
  Task GetCreditReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Document reports
  /// Operation: POST /api/v1/reports/documents
  /// </summary>
  Task GetDocumentReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Expense reports
  /// Operation: POST /api/v1/reports/expenses
  /// </summary>
  Task GetExpenseReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Invoice item reports
  /// Operation: POST /api/v1/reports/invoice_items
  /// </summary>
  Task GetInvoiceItemReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Invoice reports
  /// Operation: POST /api/v1/reports/invoices
  /// </summary>
  Task GetInvoiceReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Payment reports
  /// Operation: POST /api/v1/reports/payments
  /// </summary>
  Task GetPaymentReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Product reports
  /// Operation: POST /api/v1/reports/products
  /// </summary>
  Task GetProductReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Product Salesreports
  /// Operation: POST /api/v1/reports/product_sales
  /// </summary>
  Task GetProductSalesReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Profit loss reports
  /// Operation: POST /api/v1/reports/profitloss
  /// </summary>
  Task GetProfitLossReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Quote item reports
  /// Operation: POST /api/v1/reports/quote_items
  /// </summary>
  Task GetQuoteItemReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Quote reports
  /// Operation: POST /api/v1/reports/quotes
  /// </summary>
  Task GetQuoteReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Recurring Invoice reports
  /// Operation: POST /api/v1/reports/recurring_invoices
  /// </summary>
  Task GetRecurringInvoiceReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Task reports
  /// Operation: POST /api/v1/reports/tasks
  /// </summary>
  Task GetTaskReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Activity reports
  /// Operation: POST /api/v1/reports/activities
  /// </summary>
  Task GetActivityReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Client contact reports
  /// Operation: POST /api/v1/reports/client_contacts
  /// </summary>
  Task GetClientContactReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// AR detail report
  /// Operation: POST /api/v1/reports/ar_detail_report
  /// </summary>
  Task GetARDetailReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// AR summary report
  /// Operation: POST /api/v1/reports/ar_summary_report
  /// </summary>
  Task GetARSummaryReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Client balance report
  /// Operation: POST /api/v1/reports/client_balance_report
  /// </summary>
  Task GetClientBalanceReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Client sales report
  /// Operation: POST /api/v1/reports/client_sales_report
  /// </summary>
  Task GetClientSalesReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Tax summary report
  /// Operation: POST /api/v1/reports/tax_summary_report
  /// </summary>
  Task GetTaxSummaryReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Tax period report
  /// Operation: POST /api/v1/reports/tax_period_report
  /// </summary>
  Task GetTaxPeriodReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// User sales report
  /// Operation: POST /api/v1/reports/user_sales_report
  /// </summary>
  Task GetUserSalesReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Project reports
  /// Operation: POST /api/v1/reports/projects
  /// </summary>
  Task GetProjectReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema);

  /// <summary>
  /// Report preview
  /// Operation: POST /api/v1/reports/preview/{hash}
  /// </summary>
  Task GetReportPreviewAsync(string hash);

  /// <summary>
  /// Export preview
  /// Operation: POST /api/v1/exports/preview/{hash}
  /// </summary>
  Task GetExportPreviewAsync(string hash);

}
