

using BaseSource.Core.Application.Common.RepositoryPatttern;
using System.Reflection;

namespace BaseSource.Core.Infrastrcuture.SQL.Query;

public static class DependencyInjections
{

    public static IServiceCollection AddInfrastructureQueryServices(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        services.AddDbContext<QueryDataContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("QueryConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(QueryDataContext).Assembly.FullName);
                    // You might want different retry settings for queries
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null);
                })
            // No need for audit interceptor on read side typically
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddRepositories(assemblies);

        return services;
    }


    /// <summary>
    /// Scrutor
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assemblies"></param>
    /// <returns></returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services, Assembly[] assemblies)
    {
        services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes =>
                classes.Where(type => type.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IQueryRepository<,>))))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        // Also register the open generic fallback if needed
        //services.AddScoped(typeof(IQueryRepository<,>), typeof(QueryRepository<,>));

        return services;
    }
}
