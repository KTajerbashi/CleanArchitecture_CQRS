using CleanArchitectureCQRS.CommandsDb.Library.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureCQRS.CommandsDb.Library.DIContainer;

public static class DatabaseCommandExtensions
{
    public static IServiceCollection AddContextDatabaseCommandDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContextApplicationCommand>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
