using BaseSource.Core.Application.Providers;

namespace BaseSource.Core.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssemblies(assemblies);
        });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        services.AddScoped<ProviderFactory>();
        return services;
    }

}
