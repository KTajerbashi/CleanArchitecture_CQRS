using Serilog;
using Serilog.Events;

namespace WebApi.EndPoints.HostExtensions.ProgramStartup;

public class StartupApplication
{
    public static void StartApplication(Action action)
    {
        try
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();
            Log.Information("startUpMessage");
            action();
        }
        catch (Exception ex)
        {

            Log.Fatal(ex, ex.Message);
        }
        finally
        {
            Log.Information("shutdownMessage");
            Log.CloseAndFlush();
        }
    }
}
