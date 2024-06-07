using CleanArchitectureCQRS.Application.Library.BaseCommandQuery.Pattern;
using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.CommandsDb.Library.Database;
using CleanArchitectureCQRS.ContextDatabase.Library.Databases.Contexts;
using CleanArchitectureCQRS.QueriesDb.Library.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebApi.EndPoints.DIContainers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDatabase(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });



            builder.Services.AddScoped<ICommandApplicationContext, CommandApplicationContext>();
            services.AddDbContext<CommandApplicationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionCommandDatabase"),
                b => b.MigrationsAssembly(typeof(CommandApplicationContext).Assembly.FullName));
            });


            builder.Services.AddScoped<IQueryApplicationContext, QueryApplicationContext>();
            services.AddDbContext<QueryApplicationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionQueryDatabase"),
                b => b.MigrationsAssembly(typeof(QueryApplicationContext).Assembly.FullName));
            });
            return services;

        }
    }
}
