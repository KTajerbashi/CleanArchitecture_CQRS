using CleanArchitectureCQRS.Application.Library.Databases;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.CommandsDb.Library.Database
{

    public class CommandApplicationContext : DbContext, ICommandApplicationContext
    {
        public CommandApplicationContext(DbContextOptions<CommandApplicationContext> options)
            : base(options) { }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
