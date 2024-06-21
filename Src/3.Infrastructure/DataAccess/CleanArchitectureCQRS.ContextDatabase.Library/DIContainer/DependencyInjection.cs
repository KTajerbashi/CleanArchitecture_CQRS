using CleanArchitectureCQRS.Application.Library.Base.Application.BaseRepositories;
using CleanArchitectureCQRS.Application.Library.Catalogs.Commands.Repository;
using CleanArchitectureCQRS.ContextDatabase.Library.Base.Infrastructure;
using CleanArchitectureCQRS.ContextDatabase.Library.Catalogs;
using CleanArchitectureCQRS.ContextDatabase.Library.Databases.Contexts;
using CleanArchitectureCQRS.Domain.Library.Base.Domain.Entities;
using CleanArchitectureCQRS.Domain.Library.Catalogs.Entities;
using EventStore.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureCQRS.ContextDatabase.Library.DIContainer;

public static class DependencyInjection
{
    public static IServiceCollection AddEventStore(this IServiceCollection services, IConfiguration configuration)
    {
        // Event store database connection
        var settings = EventStoreClientSettings
                .Create("esdb://127.0.0.1:7226?tls=false&keepAliveTimeout=10000&keepAliveInterval=10000");

        var client = new EventStoreClient(settings);
        services.AddSingleton(client);

        // Register DbContext for SQL Server

        //services.AddDbContext<ApplicationContext>(options =>
        //{
        //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: sqlOptions => { });
        //});

        services.AddScoped<ICatalogItemRepository, CatalogItemRepository>();
        services.AddEventsRepository<CatalogItem, Guid>();

        return services;

    }


    private static IServiceCollection AddEventsRepository<TA, TK>(this IServiceCollection services) where TA : class, IAggregateRoot<TK>
    {
        return services.AddSingleton(typeof(IAggregateRepository<TA, TK>), typeof(AggregateRepository<TA, TK>));
    }
}