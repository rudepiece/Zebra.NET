using Zebra.NET.Services;
using Microsoft.Extensions.DependencyInjection;
using Zebra.NET.Models;

namespace Zebra.NET.Extensions;
public static class DependencyInjection
{
    public static IServiceCollection AddInvestecOpenBanking(IServiceCollection services, Authenticator options)
    {
        services.AddSingleton(new BankingService(options));
        return services;
    }
}