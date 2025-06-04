

namespace BaseSource.Utilities.DapperProvider;

public static class DependencyInjection
{
    public static IServiceCollection AddQueryExecute(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbConnection>(provider =>
        {
            var connection = new SqlConnection(); // Use your specific DbConnection here
            connection.ConnectionString = configuration.GetConnectionString("QueryDatabase");
            return connection;
        });

        //services.AddScoped<IQueryExecute, QueryExecute>();

        return services;
    }
}
