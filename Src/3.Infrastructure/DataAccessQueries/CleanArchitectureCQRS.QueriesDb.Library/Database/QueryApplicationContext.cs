using CleanArchitectureCQRS.Domain.Library.Aggregates.People.Entities;
using CleanArchitectureCQRS.QueriesDb.Library.BaseQueriesInfrastrcture;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.QueriesDb.Library.Database;

public class DbContextApplicationQuery : BaseQueryDbContext
{
    public DbContextApplicationQuery(DbContextOptions<DbContextApplicationQuery> options)
        : base(options) { }

    

    public virtual DbSet<Person> People { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
