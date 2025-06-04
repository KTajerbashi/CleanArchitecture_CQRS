

namespace BaseSource.Core.Infrastrcuture.SQL.Query;

public static class DependencyInjections
{

    public static IServiceCollection AddInfrastructureQueryServices(this IServiceCollection services, IConfiguration configuration)
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

        return services;
    }
}
