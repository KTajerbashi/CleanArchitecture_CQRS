using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace BaseSource.Utilities.Autofac;

// Marker interfaces for lifetime management
public interface IAutofacSingletonLifetime { }
public interface IAutofacScopedLifetime { }
public interface IAutofacTransientLifetime { }


public static class DependencyInjection
{
    public static ContainerBuilder AddAutofacLifetimeServices(this ContainerBuilder builder)
    {
        // Get the assembly where your services are located
        var assembly = typeof(DependencyInjection).Assembly;

        // Register services based on their lifetime interfaces
        builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.IsAssignableTo<IAutofacSingletonLifetime>())
            .AsImplementedInterfaces()
            .SingleInstance();

        builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.IsAssignableTo<IAutofacScopedLifetime>())
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.IsAssignableTo<IAutofacTransientLifetime>())
            .AsImplementedInterfaces()
            .InstancePerDependency();

        return builder;
    }

    public static IServiceProvider BuildAutofacServiceProvider(this IServiceCollection services)
    {
        var builder = new ContainerBuilder();

        // Populate Autofac with existing ASP.NET Core DI registrations
        builder.Populate(services);

        // Add our lifetime-based registrations
        builder.AddAutofacLifetimeServices();

        var container = builder.Build();
        return new AutofacServiceProvider(container);
    }
}