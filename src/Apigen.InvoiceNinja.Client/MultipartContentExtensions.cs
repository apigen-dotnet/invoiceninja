using System.Net.Http;
using System.Text.Json;
using Apigen.InvoiceNinja.Models;

namespace Apigen.InvoiceNinja.Client;

internal static class MultipartContentExtensions
{
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadCompaniesRequest uploadCompaniesRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadCompaniesRequest.Method != null)
      content.Add(new StringContent(uploadCompaniesRequest.Method), "_method");
    if (uploadCompaniesRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadCompaniesRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadExpenseRequest uploadExpenseRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadExpenseRequest.Method != null)
      content.Add(new StringContent(uploadExpenseRequest.Method), "_method");
    if (uploadExpenseRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadExpenseRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadGroupSettingRequest uploadGroupSettingRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadGroupSettingRequest.Method != null)
      content.Add(new StringContent(uploadGroupSettingRequest.Method), "_method");
    if (uploadGroupSettingRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadGroupSettingRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.PreImportRequest preImportRequest)
  {
    MultipartFormDataContent content = new();
    if (preImportRequest.ImportType != null)
      content.Add(new StringContent(preImportRequest.ImportType), "import_type");
    if (preImportRequest.FilesInvoice != null)
    {
      content.Add(new ByteArrayContent(preImportRequest.FilesInvoice), "files[invoice]", "files[invoice].bin");
    }
    if (preImportRequest.FilesClient != null)
    {
      content.Add(new ByteArrayContent(preImportRequest.FilesClient), "files[client]", "files[client].bin");
    }
    if (preImportRequest.FilesProduct != null)
    {
      content.Add(new ByteArrayContent(preImportRequest.FilesProduct), "files[product]", "files[product].bin");
    }
    if (preImportRequest.FilesPayment != null)
    {
      content.Add(new ByteArrayContent(preImportRequest.FilesPayment), "files[payment]", "files[payment].bin");
    }
    if (preImportRequest.FilesVendor != null)
    {
      content.Add(new ByteArrayContent(preImportRequest.FilesVendor), "files[vendor]", "files[vendor].bin");
    }
    if (preImportRequest.FilesExpense != null)
    {
      content.Add(new ByteArrayContent(preImportRequest.FilesExpense), "files[expense]", "files[expense].bin");
    }
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadRecurringExpenseRequest uploadRecurringExpenseRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadRecurringExpenseRequest.Method != null)
      content.Add(new StringContent(uploadRecurringExpenseRequest.Method), "_method");
    if (uploadRecurringExpenseRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadRecurringExpenseRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadRecurringInvoiceRequest uploadRecurringInvoiceRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadRecurringInvoiceRequest.Method != null)
      content.Add(new StringContent(uploadRecurringInvoiceRequest.Method), "_method");
    if (uploadRecurringInvoiceRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadRecurringInvoiceRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadProductRequest uploadProductRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadProductRequest.Method != null)
      content.Add(new StringContent(uploadProductRequest.Method), "_method");
    if (uploadProductRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadProductRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadInvoiceDocumentRequest uploadInvoiceDocumentRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadInvoiceDocumentRequest.Method != null)
      content.Add(new StringContent(uploadInvoiceDocumentRequest.Method), "_method");
    if (uploadInvoiceDocumentRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadInvoiceDocumentRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadVendorRequest uploadVendorRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadVendorRequest.Method != null)
      content.Add(new StringContent(uploadVendorRequest.Method), "_method");
    if (uploadVendorRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadVendorRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadPaymentRequest uploadPaymentRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadPaymentRequest.Method != null)
      content.Add(new StringContent(uploadPaymentRequest.Method), "_method");
    if (uploadPaymentRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadPaymentRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadQuoteRequest uploadQuoteRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadQuoteRequest.Method != null)
      content.Add(new StringContent(uploadQuoteRequest.Method), "_method");
    if (uploadQuoteRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadQuoteRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadTaskRequest uploadTaskRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadTaskRequest.Method != null)
      content.Add(new StringContent(uploadTaskRequest.Method), "_method");
    if (uploadTaskRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadTaskRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadCreditsRequest uploadCreditsRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadCreditsRequest.Method != null)
      content.Add(new StringContent(uploadCreditsRequest.Method), "_method");
    if (uploadCreditsRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadCreditsRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadProjectRequest uploadProjectRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadProjectRequest.Method != null)
      content.Add(new StringContent(uploadProjectRequest.Method), "_method");
    if (uploadProjectRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadProjectRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadPurchaseOrderRequest uploadPurchaseOrderRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadPurchaseOrderRequest.Method != null)
      content.Add(new StringContent(uploadPurchaseOrderRequest.Method), "_method");
    if (uploadPurchaseOrderRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadPurchaseOrderRequest.Documents, JsonConfig.Default)), "documents");
    return content;
  }
  public static MultipartFormDataContent ToMultipartContent(this Apigen.InvoiceNinja.Models.UploadClientRequest uploadClientRequest)
  {
    MultipartFormDataContent content = new();
    if (uploadClientRequest.Method != null)
      content.Add(new StringContent(uploadClientRequest.Method), "_method");
    if (uploadClientRequest.Documents != null)
      content.Add(new StringContent(JsonSerializer.Serialize(uploadClientRequest.Documents, JsonConfig.Default)), "documents[]");
    return content;
  }
}
