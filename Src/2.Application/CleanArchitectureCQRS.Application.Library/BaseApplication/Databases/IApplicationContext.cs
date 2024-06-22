using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.Application.Library.BaseApplication.Databases
{
    public interface IApplicationContext
    {
        Task<int> SaveChangesAsync();
    }
}
