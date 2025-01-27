using BaseSource.EndPoint.WebApi.HostExtensions.ProgramStartup;

StartupApplication.StartApplication(() =>
{
    WebApplication
            .CreateBuilder(args)
            .AddServicesApplication()
            .UsePipelineApplication()
            .Run();
});

