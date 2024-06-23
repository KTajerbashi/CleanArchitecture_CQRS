namespace CleanArchitectureCQRS.Application.Library.Databases;

public interface ICommandApplicationContext
{

    Task<int> SaveChangesAsync();
}
