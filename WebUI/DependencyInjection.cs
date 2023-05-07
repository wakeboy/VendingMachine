using FluentValidation.AspNetCore;
using VendingMachine.Application.Common.Interfaces;
using VendingMachine.WebUI.Filters;
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
        });

        services.AddHttpContextAccessor();
        services.AddScoped<ITransactionManager, TransactionManager>();

        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
            .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Virtual Vending Machine",
                Version = "v1"
            });
        });

        return services;
    }
}
