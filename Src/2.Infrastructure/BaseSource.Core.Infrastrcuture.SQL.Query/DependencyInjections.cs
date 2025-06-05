

using BaseSource.Core.Application.Common.RepositoryPatttern;
using System.Reflection;

namespace BaseSource.Core.Infrastrcuture.SQL.Query;

public static class DependencyInjections
{

    public static IServiceCollection AddInfrastructureQueryServices(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        services.AddDbContext<QueryDataContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("QueryConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(QueryDataContext).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure();
                });
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
