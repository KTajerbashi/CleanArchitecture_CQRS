using CleanArchitectureCQRS.QueriesDb.Library.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureCQRS.QueriesDb.Library.DIContainer;

public static class DatabaseQueryExtensions
{
    public static IServiceCollection AddContextDatabaseQueryDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContextApplicationQuery>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
