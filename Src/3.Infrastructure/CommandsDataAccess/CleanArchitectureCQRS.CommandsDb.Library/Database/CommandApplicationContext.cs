using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Domain.Library.Person.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
