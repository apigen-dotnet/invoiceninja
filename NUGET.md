# Apigen.InvoiceNinja

Generated C# client for the [Invoice Ninja](https://invoiceninja.com/) v5 API.

## Installation

```bash
dotnet add package Apigen.InvoiceNinja.Client
```

The `Apigen.InvoiceNinja.Models` package is included as a dependency.

## Usage

```csharp
using Apigen.InvoiceNinja.Client;
using Apigen.InvoiceNinja.Models;

// Create client with API key
var client = InvoiceNinjaApiClient.WithApiKey(
    "your-api-token",
    "https://your-instance.invoiceninja.com");

// Or use a pre-configured HttpClient
var client = new InvoiceNinjaApiClient(httpClient);
```

## Versioning

Package versions follow the upstream application version: the **major.minor** matches the application API version, and the **patch** is our client revision. For example, package `2.6.7` was built against API version `2.6.x` and is our 7th client release for that API version.

## License

MIT
