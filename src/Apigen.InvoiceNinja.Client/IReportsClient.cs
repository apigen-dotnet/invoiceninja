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
  Task GetContactReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetContactReportRequest? request = null);

  /// <summary>
  /// Client reports
  /// Operation: POST /api/v1/reports/clients
  /// </summary>
  Task GetClientReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetClientReportRequest? request = null);

  /// <summary>
  /// Credit reports
  /// Operation: POST /api/v1/reports/credit
  /// </summary>
  Task GetCreditReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetCreditReportRequest? request = null);

  /// <summary>
  /// Document reports
  /// Operation: POST /api/v1/reports/documents
  /// </summary>
  Task GetDocumentReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetDocumentReportRequest? request = null);

  /// <summary>
  /// Expense reports
  /// Operation: POST /api/v1/reports/expense
  /// </summary>
  Task GetExpenseReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetExpenseReportRequest? request = null);

  /// <summary>
  /// Invoice item reports
  /// Operation: POST /api/v1/reports/invoice_items
  /// </summary>
  Task GetInvoiceItemReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetInvoiceItemReportRequest? request = null);

  /// <summary>
  /// Invoice reports
  /// Operation: POST /api/v1/reports/invoices
  /// </summary>
  Task GetInvoiceReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetInvoiceReportRequest? request = null);

  /// <summary>
  /// Payment reports
  /// Operation: POST /api/v1/reports/payments
  /// </summary>
  Task GetPaymentReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetPaymentReportRequest? request = null);

  /// <summary>
  /// Product reports
  /// Operation: POST /api/v1/reports/products
  /// </summary>
  Task GetProductReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetProductReportRequest? request = null);

  /// <summary>
  /// Product Salesreports
  /// Operation: POST /api/v1/reports/product_sales
  /// </summary>
  Task GetProductSalesReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetProductSalesReportRequest? request = null);

  /// <summary>
  /// Profit loss reports
  /// Operation: POST /api/v1/reports/profitloss
  /// </summary>
  Task GetProfitLossReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetProfitLossReportRequest? request = null);

  /// <summary>
  /// Quote item reports
  /// Operation: POST /api/v1/reports/quote_items
  /// </summary>
  Task GetQuoteItemReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetQuoteItemReportRequest? request = null);

  /// <summary>
  /// Quote reports
  /// Operation: POST /api/v1/reports/quotes
  /// </summary>
  Task GetQuoteReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetQuoteReportRequest? request = null);

  /// <summary>
  /// Recurring Invoice reports
  /// Operation: POST /api/v1/reports/recurring_invoices
  /// </summary>
  Task GetRecurringInvoiceReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetRecurringInvoiceReportRequest? request = null);

  /// <summary>
  /// Task reports
  /// Operation: POST /api/v1/reports/tasks
  /// </summary>
  Task GetTaskReportAsync(Apigen.InvoiceNinja.Models.GenericReportSchema genericReportSchema, GetTaskReportRequest? request = null);

}
