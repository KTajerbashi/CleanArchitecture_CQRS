using BaseSource.Utilities.CacheProvider.InMemory;
using BaseSource.Utilities.CacheProvider.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseSource.Utilities.CacheProvider;

public static class DependencyInjections
{
    //public static IServiceCollection AddRedisDistributedCache(
    //    this IServiceCollection services,IConfiguration configuration,string sectionName)
    //    => services.AddRedisDistributedCache(configuration.GetSection(sectionName));

    //public static IServiceCollection AddRedisDistributedCache(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddTransient<ICacheAdapter, RedisCacheAdapter>();
    //    services.Configure<RedisCacheOptions>(configuration);

    //    var option = configuration.Get<RedisCacheOptions>();

    //    services.AddStackExchangeRedisCache(options =>
    //    {
    //        options.Configuration = option.Configuration;
    //        options.InstanceName = option.InstanceName;
    //    });

    //    return services;
    //}

    //public static IServiceCollection AddRedisDistributedCache(this IServiceCollection services,
    //                                                          Action<RedisCacheOptions> setupAction)
    //{
    //    services.AddTransient<ICacheAdapter, RedisCacheAdapter>();
    //    services.Configure(setupAction);

    //    var option = new RedisCacheOptions();
    //    setupAction.Invoke(option);

    //    services.AddStackExchangeRedisCache(options =>
    //    {
    //        options.Configuration = option.Configuration;
    //        options.InstanceName = option.InstanceName;
    //    });

    //    return services;
    //}

    public static IServiceCollection AddInMemoryCaching(this IServiceCollection services)
        => services.AddMemoryCache().AddTransient<ICacheAdapter, InMemoryCacheAdapter>();
}