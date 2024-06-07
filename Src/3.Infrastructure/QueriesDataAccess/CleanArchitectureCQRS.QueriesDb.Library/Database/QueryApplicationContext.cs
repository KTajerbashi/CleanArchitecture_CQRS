using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Domain.Library.Person.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
