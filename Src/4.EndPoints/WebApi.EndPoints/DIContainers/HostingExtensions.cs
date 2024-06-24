using CleanArchitectureCQRS.CommandsDb.Library.BaseCommandInfrastrcture.Intercepters;
using CleanArchitectureCQRS.CommandsDb.Library.Database;
using CleanArchitectureCQRS.QueriesDb.Library.Database;
using Microsoft.EntityFrameworkCore;

namespace WebApi.EndPoints.DIContainers
{
    public static class HostingExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //CommandDbContext
            services.AddDbContext<DbContextApplicationCommand>(
                c =>
                    c.UseSqlServer(configuration.GetConnectionString("DefaultConnectionCommandDatabase"))
                     .AddInterceptors(new SetPersianYeKeInterceptor(),
                                 new AddAuditDataInterceptor()));

            //QueryDbContext
            services.AddDbContext<DbContextApplicationQueries>(
                c => c.UseSqlServer(configuration.GetConnectionString("DefaultConnectionQueryDatabase")));

            return services;
        }
    }
}
