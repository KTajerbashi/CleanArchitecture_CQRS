namespace BaseSource.Utilities;

public static class DependencyInjections
{
    public static IServiceCollection AddBaseSourceUtilities(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMicrosoftSerializer();
        
        services.AddQueryExecute(configuration);
        
        services.AddScrutorProvider();
        return services;
    }
}
