using BaseSource.Infra.Data.Sql.Command.Library.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseSource.Infra.Data.Sql.Command.Library;

public static class DependencyInjections
{
    public static IServiceCollection AddCommandInfrastructureLibrary(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContextCommand>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
