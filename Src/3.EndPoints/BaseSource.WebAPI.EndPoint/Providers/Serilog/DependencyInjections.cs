using Serilog;

namespace BaseSource.WebAPI.EndPoint.Providers.Serilog;

public static class DependencyInjections
{
    public static WebApplicationBuilder AddSerilogService(this WebApplicationBuilder builder)
    {
        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        builder.Host.UseSerilog();

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<LogActionFilter>();
        });

        return builder;
    }
}
