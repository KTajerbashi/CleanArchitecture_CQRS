

namespace BaseSource.Core.Infrastrcuture.SQL.Command;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureCommandServices(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddDbContext<CommandDataContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("CommandConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(CommandDataContext).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure();
                });
        });
        return services;
    }
}
