using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Domain.Library.People.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.QueriesDb.Library.Database
{
    public class QueryApplicationContext : DbContext, IQueryApplicationContext
    {
        public DbSet<Person> People { get; set; }
        public QueryApplicationContext(DbContextOptions<QueryApplicationContext> options)
            : base(options) { }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
