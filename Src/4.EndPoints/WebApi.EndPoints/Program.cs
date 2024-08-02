using WebApi.EndPoints.HostExtensions.ServiceExtensions;
using WebApi.EndPoints.HostExtensions.StartUp;


StartupApplication.StartApplication(() =>
{
    WebApplication
            .CreateBuilder(args)
            .ApplicationServices()
            .ApplicationPipeline()
            .RunAsync();
});

