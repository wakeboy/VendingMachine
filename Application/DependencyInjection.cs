using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VendingMachine.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
