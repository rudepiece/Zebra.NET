using Zebra.NET.Services;
using Microsoft.Extensions.DependencyInjection;
using Zebra.NET.Interfaces;
using Zebra.NET.Models;

namespace Zebra.NET.Extensions;
public static class DependencyInjection
{
    public static IServiceCollection AddInvestecOpenBanking(this IServiceCollection services, Authenticator options)
    {
        services.AddSingleton<IBankingService>(new BankingService(options));
        return services;
    }
}