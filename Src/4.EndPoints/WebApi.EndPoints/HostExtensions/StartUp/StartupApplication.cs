namespace WebApi.EndPoints.HostExtensions.StartUp;

public class StartupApplication
{
    public static void StartApplication(Action action)
    {
		try
		{
			action();
		}
		catch (Exception)
		{

			throw;
		}
    }
}
