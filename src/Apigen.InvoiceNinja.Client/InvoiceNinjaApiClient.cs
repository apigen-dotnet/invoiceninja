using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Apigen.InvoiceNinja.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.InvoiceNinja.Client;

/// <summary>
/// Main API client for accessing all resources
/// </summary>
public partial class InvoiceNinjaApiClient
{
  private readonly HttpClient _httpClient;
  private readonly bool _disposeHttpClient;
  private readonly ILogger? _logger;

  /// <summary>
  /// Client for activities operations
  /// </summary>
  public ActivitiesClient Activities { get; }

  /// <summary>
  /// Client for auth operations
  /// </summary>
  public AuthClient Auth { get; }

  /// <summary>
  /// Client for settings operations
  /// </summary>
  public SettingsClient Settings { get; }

  /// <summary>
  /// Client for refresh operations
  /// </summary>
  public RefreshClient Refresh { get; }

  /// <summary>
  /// Client for yodlee operations
  /// </summary>
  public YodleeClient Yodlee { get; }

  /// <summary>
  /// Client for bank_integrations operations
  /// </summary>
  public BankIntegrationsClient BankIntegrations { get; }

  /// <summary>
  /// Client for bank_transactions operations
  /// </summary>
  public BankTransactionsClient BankTransactions { get; }

  /// <summary>
  /// Client for bank_transaction_rules operations
  /// </summary>
  public BankTransactionRulesClient BankTransactionRules { get; }

  /// <summary>
  /// Client for charts operations
  /// </summary>
  public ChartsClient Charts { get; }

  /// <summary>
  /// Client for client_gateway_tokens operations
  /// </summary>
  public ClientGatewayTokensClient ClientGatewayTokens { get; }

  /// <summary>
  /// Client for companies operations
  /// </summary>
  public CompaniesClient Companies { get; }

  /// <summary>
  /// Client for company_gateways operations
  /// </summary>
  public CompanyGatewaysClient CompanyGateways { get; }

  /// <summary>
  /// Client for company_ledger operations
  /// </summary>
  public CompanyLedgerClient CompanyLedger { get; }

  /// <summary>
  /// Client for company_user operations
  /// </summary>
  public CompanyUserClient CompanyUser { get; }

  /// <summary>
  /// Client for connected_account operations
  /// </summary>
  public ConnectedAccountClient ConnectedAccount { get; }

  /// <summary>
  /// Client for designs operations
  /// </summary>
  public DesignsClient Designs { get; }

  /// <summary>
  /// Client for documents operations
  /// </summary>
  public DocumentsClient Documents { get; }

  /// <summary>
  /// Client for emails operations
  /// </summary>
  public EmailsClient Emails { get; }

  /// <summary>
  /// Client for expense_categories operations
  /// </summary>
  public ExpenseCategoriesClient ExpenseCategories { get; }

  /// <summary>
  /// Client for expenses operations
  /// </summary>
  public ExpensesClient Expenses { get; }

  /// <summary>
  /// Client for expense operations
  /// </summary>
  public ExpenseClient Expense { get; }

  /// <summary>
  /// Client for export operations
  /// </summary>
  public ExportClient Export { get; }

  /// <summary>
  /// Client for group_settings operations
  /// </summary>
  public GroupSettingsClient GroupSettings { get; }

  /// <summary>
  /// Client for imports operations
  /// </summary>
  public ImportsClient Imports { get; }

  /// <summary>
  /// Client for import operations
  /// </summary>
  public ImportClient Import { get; }

  /// <summary>
  /// Client for postmark operations
  /// </summary>
  public PostmarkClient Postmark { get; }

  /// <summary>
  /// Client for claim_license operations
  /// </summary>
  public ClaimLicenseClient ClaimLicense { get; }

  /// <summary>
  /// Client for logout operations
  /// </summary>
  public LogoutClient Logout { get; }

  /// <summary>
  /// Client for migration operations
  /// </summary>
  public MigrationClient Migration { get; }

  /// <summary>
  /// Client for one_time_token operations
  /// </summary>
  public OneTimeTokenClient OneTimeToken { get; }

  /// <summary>
  /// Client for payment_terms operations
  /// </summary>
  public PaymentTermsClient PaymentTerms { get; }

  /// <summary>
  /// Client for payment_termss operations
  /// </summary>
  public PaymentTermssClient PaymentTermss { get; }

  /// <summary>
  /// Client for ping operations
  /// </summary>
  public PingClient Ping { get; }

  /// <summary>
  /// Client for health_check operations
  /// </summary>
  public HealthCheckClient HealthCheck { get; }

  /// <summary>
  /// Client for preview operations
  /// </summary>
  public PreviewClient Preview { get; }

  /// <summary>
  /// Client for recurring_expenses operations
  /// </summary>
  public RecurringExpensesClient RecurringExpenses { get; }

  /// <summary>
  /// Client for recurring_expense operations
  /// </summary>
  public RecurringExpenseClient RecurringExpense { get; }

  /// <summary>
  /// Client for recurring_quotes operations
  /// </summary>
  public RecurringQuotesClient RecurringQuotes { get; }

  /// <summary>
  /// Client for reports operations
  /// </summary>
  public ReportsClient Reports { get; }

  /// <summary>
  /// Client for update operations
  /// </summary>
  public UpdateClient Update { get; }

  /// <summary>
  /// Client for statics operations
  /// </summary>
  public StaticsClient Statics { get; }

  /// <summary>
  /// Client for subscriptions operations
  /// </summary>
  public SubscriptionsClient Subscriptions { get; }

  /// <summary>
  /// Client for scheduler operations
  /// </summary>
  public SchedulerClient Scheduler { get; }

  /// <summary>
  /// Client for support operations
  /// </summary>
  public SupportClient Support { get; }

  /// <summary>
  /// Client for system_logs operations
  /// </summary>
  public SystemLogsClient SystemLogs { get; }

  /// <summary>
  /// Client for task_schedulers operations
  /// </summary>
  public TaskSchedulersClient TaskSchedulers { get; }

  /// <summary>
  /// Client for task_status operations
  /// </summary>
  public TaskItemStatusClient TaskStatus { get; }

  /// <summary>
  /// Client for task_statuss operations
  /// </summary>
  public TaskStatussClient TaskStatuss { get; }

  /// <summary>
  /// Client for tax_rates operations
  /// </summary>
  public TaxRatesClient TaxRates { get; }

  /// <summary>
  /// Client for templates operations
  /// </summary>
  public TemplatesClient Templates { get; }

  /// <summary>
  /// Client for search operations
  /// </summary>
  public SearchClient Search { get; }

  /// <summary>
  /// Client for tokens operations
  /// </summary>
  public TokensClient Tokens { get; }

  /// <summary>
  /// Client for users operations
  /// </summary>
  public UsersClient Users { get; }

  /// <summary>
  /// Client for webcron operations
  /// </summary>
  public WebcronClient Webcron { get; }

  /// <summary>
  /// Client for webhooks operations
  /// </summary>
  public WebhooksClient Webhooks { get; }

  /// <summary>
  /// Client for Recurring Invoices operations
  /// </summary>
  public RecurringInvoicesClient RecurringInvoices { get; }

  /// <summary>
  /// Client for products operations
  /// </summary>
  public ProductsClient Products { get; }

  /// <summary>
  /// Client for invoices operations
  /// </summary>
  public InvoicesClient Invoices { get; }

  /// <summary>
  /// Client for vendors operations
  /// </summary>
  public VendorsClient Vendors { get; }

  /// <summary>
  /// Client for payments operations
  /// </summary>
  public PaymentsClient Payments { get; }

  /// <summary>
  /// Client for quotes operations
  /// </summary>
  public QuotesClient Quotes { get; }

  /// <summary>
  /// Client for tasks operations
  /// </summary>
  public TasksClient Tasks { get; }

  /// <summary>
  /// Client for credits operations
  /// </summary>
  public CreditsClient Credits { get; }

  /// <summary>
  /// Client for projects operations
  /// </summary>
  public ProjectsClient Projects { get; }

  /// <summary>
  /// Client for Purchase Orders operations
  /// </summary>
  public PurchaseOrdersClient PurchaseOrders { get; }

  /// <summary>
  /// Client for locations operations
  /// </summary>
  public LocationsClient Locations { get; }

  /// <summary>
  /// Client for clients operations
  /// </summary>
  public ClientsClient Clients { get; }

  /// <summary>
  /// Initialize client with a pre-configured HttpClient
  /// </summary>
  /// <param name="httpClient">Pre-configured HttpClient with base address, auth headers, etc.</param>
  /// <param name="logger">Optional logger for request/response logging</param>
  public InvoiceNinjaApiClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _disposeHttpClient = false;
    _logger = logger;

    Activities = new ActivitiesClient(_httpClient, _logger);
    Auth = new AuthClient(_httpClient, _logger);
    Settings = new SettingsClient(_httpClient, _logger);
    Refresh = new RefreshClient(_httpClient, _logger);
    Yodlee = new YodleeClient(_httpClient, _logger);
    BankIntegrations = new BankIntegrationsClient(_httpClient, _logger);
    BankTransactions = new BankTransactionsClient(_httpClient, _logger);
    BankTransactionRules = new BankTransactionRulesClient(_httpClient, _logger);
    Charts = new ChartsClient(_httpClient, _logger);
    ClientGatewayTokens = new ClientGatewayTokensClient(_httpClient, _logger);
    Companies = new CompaniesClient(_httpClient, _logger);
    CompanyGateways = new CompanyGatewaysClient(_httpClient, _logger);
    CompanyLedger = new CompanyLedgerClient(_httpClient, _logger);
    CompanyUser = new CompanyUserClient(_httpClient, _logger);
    ConnectedAccount = new ConnectedAccountClient(_httpClient, _logger);
    Designs = new DesignsClient(_httpClient, _logger);
    Documents = new DocumentsClient(_httpClient, _logger);
    Emails = new EmailsClient(_httpClient, _logger);
    ExpenseCategories = new ExpenseCategoriesClient(_httpClient, _logger);
    Expenses = new ExpensesClient(_httpClient, _logger);
    Expense = new ExpenseClient(_httpClient, _logger);
    Export = new ExportClient(_httpClient, _logger);
    GroupSettings = new GroupSettingsClient(_httpClient, _logger);
    Imports = new ImportsClient(_httpClient, _logger);
    Import = new ImportClient(_httpClient, _logger);
    Postmark = new PostmarkClient(_httpClient, _logger);
    ClaimLicense = new ClaimLicenseClient(_httpClient, _logger);
    Logout = new LogoutClient(_httpClient, _logger);
    Migration = new MigrationClient(_httpClient, _logger);
    OneTimeToken = new OneTimeTokenClient(_httpClient, _logger);
    PaymentTerms = new PaymentTermsClient(_httpClient, _logger);
    PaymentTermss = new PaymentTermssClient(_httpClient, _logger);
    Ping = new PingClient(_httpClient, _logger);
    HealthCheck = new HealthCheckClient(_httpClient, _logger);
    Preview = new PreviewClient(_httpClient, _logger);
    RecurringExpenses = new RecurringExpensesClient(_httpClient, _logger);
    RecurringExpense = new RecurringExpenseClient(_httpClient, _logger);
    RecurringQuotes = new RecurringQuotesClient(_httpClient, _logger);
    Reports = new ReportsClient(_httpClient, _logger);
    Update = new UpdateClient(_httpClient, _logger);
    Statics = new StaticsClient(_httpClient, _logger);
    Subscriptions = new SubscriptionsClient(_httpClient, _logger);
    Scheduler = new SchedulerClient(_httpClient, _logger);
    Support = new SupportClient(_httpClient, _logger);
    SystemLogs = new SystemLogsClient(_httpClient, _logger);
    TaskSchedulers = new TaskSchedulersClient(_httpClient, _logger);
    TaskStatus = new TaskItemStatusClient(_httpClient, _logger);
    TaskStatuss = new TaskStatussClient(_httpClient, _logger);
    TaxRates = new TaxRatesClient(_httpClient, _logger);
    Templates = new TemplatesClient(_httpClient, _logger);
    Search = new SearchClient(_httpClient, _logger);
    Tokens = new TokensClient(_httpClient, _logger);
    Users = new UsersClient(_httpClient, _logger);
    Webcron = new WebcronClient(_httpClient, _logger);
    Webhooks = new WebhooksClient(_httpClient, _logger);
    RecurringInvoices = new RecurringInvoicesClient(_httpClient, _logger);
    Products = new ProductsClient(_httpClient, _logger);
    Invoices = new InvoicesClient(_httpClient, _logger);
    Vendors = new VendorsClient(_httpClient, _logger);
    Payments = new PaymentsClient(_httpClient, _logger);
    Quotes = new QuotesClient(_httpClient, _logger);
    Tasks = new TasksClient(_httpClient, _logger);
    Credits = new CreditsClient(_httpClient, _logger);
    Projects = new ProjectsClient(_httpClient, _logger);
    PurchaseOrders = new PurchaseOrdersClient(_httpClient, _logger);
    Locations = new LocationsClient(_httpClient, _logger);
    Clients = new ClientsClient(_httpClient, _logger);
  }

  private InvoiceNinjaApiClient(HttpClient httpClient, bool disposeHttpClient, ILogger? logger)
  {
    _httpClient = httpClient;
    _disposeHttpClient = disposeHttpClient;
    _logger = logger;

    Activities = new ActivitiesClient(_httpClient, _logger);
    Auth = new AuthClient(_httpClient, _logger);
    Settings = new SettingsClient(_httpClient, _logger);
    Refresh = new RefreshClient(_httpClient, _logger);
    Yodlee = new YodleeClient(_httpClient, _logger);
    BankIntegrations = new BankIntegrationsClient(_httpClient, _logger);
    BankTransactions = new BankTransactionsClient(_httpClient, _logger);
    BankTransactionRules = new BankTransactionRulesClient(_httpClient, _logger);
    Charts = new ChartsClient(_httpClient, _logger);
    ClientGatewayTokens = new ClientGatewayTokensClient(_httpClient, _logger);
    Companies = new CompaniesClient(_httpClient, _logger);
    CompanyGateways = new CompanyGatewaysClient(_httpClient, _logger);
    CompanyLedger = new CompanyLedgerClient(_httpClient, _logger);
    CompanyUser = new CompanyUserClient(_httpClient, _logger);
    ConnectedAccount = new ConnectedAccountClient(_httpClient, _logger);
    Designs = new DesignsClient(_httpClient, _logger);
    Documents = new DocumentsClient(_httpClient, _logger);
    Emails = new EmailsClient(_httpClient, _logger);
    ExpenseCategories = new ExpenseCategoriesClient(_httpClient, _logger);
    Expenses = new ExpensesClient(_httpClient, _logger);
    Expense = new ExpenseClient(_httpClient, _logger);
    Export = new ExportClient(_httpClient, _logger);
    GroupSettings = new GroupSettingsClient(_httpClient, _logger);
    Imports = new ImportsClient(_httpClient, _logger);
    Import = new ImportClient(_httpClient, _logger);
    Postmark = new PostmarkClient(_httpClient, _logger);
    ClaimLicense = new ClaimLicenseClient(_httpClient, _logger);
    Logout = new LogoutClient(_httpClient, _logger);
    Migration = new MigrationClient(_httpClient, _logger);
    OneTimeToken = new OneTimeTokenClient(_httpClient, _logger);
    PaymentTerms = new PaymentTermsClient(_httpClient, _logger);
    PaymentTermss = new PaymentTermssClient(_httpClient, _logger);
    Ping = new PingClient(_httpClient, _logger);
    HealthCheck = new HealthCheckClient(_httpClient, _logger);
    Preview = new PreviewClient(_httpClient, _logger);
    RecurringExpenses = new RecurringExpensesClient(_httpClient, _logger);
    RecurringExpense = new RecurringExpenseClient(_httpClient, _logger);
    RecurringQuotes = new RecurringQuotesClient(_httpClient, _logger);
    Reports = new ReportsClient(_httpClient, _logger);
    Update = new UpdateClient(_httpClient, _logger);
    Statics = new StaticsClient(_httpClient, _logger);
    Subscriptions = new SubscriptionsClient(_httpClient, _logger);
    Scheduler = new SchedulerClient(_httpClient, _logger);
    Support = new SupportClient(_httpClient, _logger);
    SystemLogs = new SystemLogsClient(_httpClient, _logger);
    TaskSchedulers = new TaskSchedulersClient(_httpClient, _logger);
    TaskStatus = new TaskItemStatusClient(_httpClient, _logger);
    TaskStatuss = new TaskStatussClient(_httpClient, _logger);
    TaxRates = new TaxRatesClient(_httpClient, _logger);
    Templates = new TemplatesClient(_httpClient, _logger);
    Search = new SearchClient(_httpClient, _logger);
    Tokens = new TokensClient(_httpClient, _logger);
    Users = new UsersClient(_httpClient, _logger);
    Webcron = new WebcronClient(_httpClient, _logger);
    Webhooks = new WebhooksClient(_httpClient, _logger);
    RecurringInvoices = new RecurringInvoicesClient(_httpClient, _logger);
    Products = new ProductsClient(_httpClient, _logger);
    Invoices = new InvoicesClient(_httpClient, _logger);
    Vendors = new VendorsClient(_httpClient, _logger);
    Payments = new PaymentsClient(_httpClient, _logger);
    Quotes = new QuotesClient(_httpClient, _logger);
    Tasks = new TasksClient(_httpClient, _logger);
    Credits = new CreditsClient(_httpClient, _logger);
    Projects = new ProjectsClient(_httpClient, _logger);
    PurchaseOrders = new PurchaseOrdersClient(_httpClient, _logger);
    Locations = new LocationsClient(_httpClient, _logger);
    Clients = new ClientsClient(_httpClient, _logger);
  }

  /// <summary>
  /// Create client with API key authentication
  /// </summary>
  public static InvoiceNinjaApiClient WithApiKey(string apiKey, string baseUrl = "https://demo.invoiceninja.com", ILogger? logger = null)
  {
    HttpClient httpClient = CreateTokenAuthHttpClient(apiKey, baseUrl, "X-API-TOKEN", false);
    return new InvoiceNinjaApiClient(httpClient, true, logger);
  }

  private static HttpClient CreateTokenAuthHttpClient(string apiToken, string baseUrl, string headerName, bool useBearer)
  {
    // Ensure baseUrl ends with / for proper Uri combining with relative paths
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    HttpClient client = new() { BaseAddress = new Uri(normalizedBaseUrl) };

    if (useBearer)
    {
      client.DefaultRequestHeaders.Add(headerName, $"Bearer {apiToken}");
    }
    else
    {
      client.DefaultRequestHeaders.Add(headerName, apiToken);
    }

    client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
    return client;
  }

  private static HttpClient CreateBasicAuthHttpClient(string username, string password, string baseUrl)
  {
    // Ensure baseUrl ends with / for proper Uri combining with relative paths
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    HttpClient client = new() { BaseAddress = new Uri(normalizedBaseUrl) };

    string credentials = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{username}:{password}"));
    client.DefaultRequestHeaders.Add("Authorization", $"Basic {credentials}");

    client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
    return client;
  }

  private static HttpClient CreateCookieAuthHttpClient(string token, string cookieName, string baseUrl)
  {
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    System.Net.CookieContainer cookies = new();
    cookies.Add(new Uri(normalizedBaseUrl), new System.Net.Cookie(cookieName, token));
    HttpClientHandler handler = new() { CookieContainer = cookies };
    HttpClient client = new(handler) { BaseAddress = new Uri(normalizedBaseUrl) };

    client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
    return client;
  }

  /// <summary>
  /// Dispose resources
  /// </summary>
  public void Dispose()
  {
    if (_disposeHttpClient)
    {
      _httpClient?.Dispose();
    }
  }
}
