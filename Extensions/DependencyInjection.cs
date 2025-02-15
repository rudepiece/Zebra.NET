using investec.Models;
using investec.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Zebra.NET.Extensions;
public static class DependencyInjection
{
    public static IServiceCollection AddInvestecOpenBanking(IServiceCollection services, Authenticator options)
    {
        services.AddSingleton(new BankingService(options));
        return services;
    }
}