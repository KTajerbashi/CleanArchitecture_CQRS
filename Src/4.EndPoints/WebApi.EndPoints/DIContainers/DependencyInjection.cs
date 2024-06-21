using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.ContextDatabase.Library.Databases.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApi.EndPoints.DIContainers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDatabase(this IServiceCollection services, WebApplicationBuilder builder)
        {
            //// Sample Database Config
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });
            builder.Services.AddScoped<IApplicationContext, ApplicationContext>();


            ////// Command Database Config
            //services.AddDbContext<CommandApplicationContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionCommandDatabase"),
            //    b => b.MigrationsAssembly(typeof(CommandApplicationContext).Assembly.FullName));
            //});
            //builder.Services.AddScoped<ICommandApplicationContext, CommandApplicationContext>();


            ////// Query Database Config
            //services.AddDbContext<QueryApplicationContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionQueryDatabase"),
            //    b => b.MigrationsAssembly(typeof(QueryApplicationContext).Assembly.FullName));
            //});
            //builder.Services.AddScoped<IQueryApplicationContext, QueryApplicationContext>();
            return services;

        }
    }
}
