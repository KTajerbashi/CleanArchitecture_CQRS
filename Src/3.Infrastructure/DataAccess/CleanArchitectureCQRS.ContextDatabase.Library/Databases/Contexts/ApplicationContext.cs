

using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Domain.Library.Person.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.ContextDatabase.Library.Databases.Contexts
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Person> People { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
