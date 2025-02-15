# Investec C# API Wrapper (.NET 8)

This client library enables client applications to connect to Investec's Open Banking APIs, refer to [Investec OpenAPI Documentation](https://developer.investec.com/programmable-banking/#open-api/).

## Usage

Register and configure the service with the `AddInvestecOpenBanking` extension method.

### Startup Configuration

In your `Startup.cs` or equivalent configuration file, add the following code to set up dependency injection for the Investec Open Banking client.

```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using investec.Extensions;
using investec.Models;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add other services

        // Configure Investec Open Banking client service
       builder.Services.AddInvestecOpenBanking(
            new Authenticator(builder.Configuration, false, "YourClientId", "YourClientSecret", "YourApiKey"));
        
        // Add other services
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline
    }
}
```

### Environment Variables

If the `ClientId`, `ClientSecret`, and `ApiKey` are not explicitly passed in, the library will attempt to retrieve them from environment variables. In this case ensure the following environment variables are set:
- `Investec_ClientId`
- `Investec_ClientSecret`
- `Investec_ApiKey`

### Configuration JSON

Alternatively, you can configure these values in your `appsettings.json` file:

```json
{
  "Investec": {
    "ClientId": "YourClientId",
    "ClientSecret": "YourClientSecret",
    "ApiKey": "YourApiKey"
  }
}
```

### Injecting and Using the Service

Once the service is registered, you can inject it into your controllers or services as needed.

```csharp
using Microsoft.AspNetCore.Mvc;
using investec.Services;

public class BankingController : ControllerBase
{
    private readonly BankingService _bankingService;

    public BankingController(BankingService bankingService)
    {
        _bankingService = bankingService;
    }

    [HttpGet("accounts")]
    public async Task<IActionResult> GetAccounts()
    {
        var accounts = await _bankingService.GetAccounts();
        return Ok(accounts);
    }

    [HttpGet("transactions/{accountId}")]
    public async Task<IActionResult> GetTransactions(string accountId)
    {
        var transactions = await _bankingService.GetAccountTransactions(accountId);
        return Ok(transactions);
    }
}
```

## Install via [Nuget.org](https://www.nuget.org/)

`Install-Package Zebra.Net`

| NuGet Stable                                                                                                                  | NuGet Pre-release | Downloads |
|-------------------------------------------------------------------------------------------------------------------------------| ----------------- | --------- |
| [![Zebra.Net](https://img.shields.io/nuget/v/Zebra.Net.svg)](https://www.nuget.org/packages/Zebra.Net/) | [![Zebra.Net](https://img.shields.io/nuget/vpre/Zebra.Net.svg)](https://www.nuget.org/packages/Zebra.Net/) | [![Zebra.Net](https://img.shields.io/nuget/dt/Zebra.Net.svg)](https://www.nuget.org/packages/Zebra.Net/) |

## Useful Links

* Documentation
  * [Investec Developer Portal](https://developer.investec.com/programmable-banking/#open-api/)

## Additional Information

- This library is built on .NET 8.
- It leverages the RestSharp library for making HTTP requests.

For more information, refer to the [Investec Developer Portal](https://developer.investec.com/programmable-banking/#open-api/).
