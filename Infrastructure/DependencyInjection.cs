using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Application.Common.Interfaces;
using VendingMachine.Infrastructure.Persistence;

namespace VendingMachine.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddSingleton<IWalletRepository, WalletRepository>();

        return services;
    }
}
