using VendingMachine.Application.Common.Interfaces;
using VendingMachine.WebUI.Services;

namespace VendingMachine.WebUI;

public static class DependencyInjection
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.Cookie.Name = "VendingMachineSession";
            options.IdleTimeout = TimeSpan.FromMinutes(30);
        });

        services.AddHttpContextAccessor();
        services.AddScoped<ITransactionManager, TransactionManager>();
        services.AddControllersWithViews();

        return services;
    }
}
