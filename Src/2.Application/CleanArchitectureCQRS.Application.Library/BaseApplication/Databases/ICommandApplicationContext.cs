namespace CleanArchitectureCQRS.Application.Library.BaseApplication.Databases;

public interface ICommandApplicationContext
{

    Task<int> SaveChangesAsync();
}
