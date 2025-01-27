using BaseSource.Infra.Data.Sql.Query.Library.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseSource.Infra.Data.Sql.Query.Library;

public static class DependencyInjections
{
    public static IServiceCollection AddQueryInfrastructureLibrary(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContextApplicationQuery>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
