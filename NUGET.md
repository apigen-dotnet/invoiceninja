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

## License

MIT
