using WebApi.EndPoints.HostExtensions.ProgramStartup;


StartupApplication.StartApplication(() =>
{
    WebApplication
            .CreateBuilder(args)
            .AddServicesApplication()
            .UsePipelineApplication()
            .Run();
});

