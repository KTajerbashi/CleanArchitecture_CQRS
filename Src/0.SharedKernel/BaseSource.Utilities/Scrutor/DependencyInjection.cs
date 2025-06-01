using System.Reflection;

namespace BaseSource.Utilities.Scrutor;

public static class DependencyInjection
{
    public static IServiceCollection AddScrutorProvider(this IServiceCollection services)
    {
        // Get the assembly where your services are located
        var assembly = typeof(DependencyInjection).Assembly;

        // Register services with Scrutor based on their lifetime interfaces
        services.Scan(scan => scan
            .FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo<ISingletonLifetime>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime()

            .AddClasses(classes => classes.AssignableTo<IScopedLifetime>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()

            .AddClasses(classes => classes.AssignableTo<ITransientLifetime>())
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );

        return services;
    }
}