using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Domain.Library.People.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.CommandsDb.Library.Database
{

    public class CommandApplicationContext : DbContext, ICommandApplicationContext
    {
        public DbSet<Person> People { get; set; }
        public CommandApplicationContext(DbContextOptions<CommandApplicationContext> options)
            : base(options) { }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
