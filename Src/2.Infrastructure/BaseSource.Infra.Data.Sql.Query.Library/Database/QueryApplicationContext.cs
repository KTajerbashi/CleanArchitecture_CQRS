using BaseSource.Core.Domain.Library.Aggregates.People.Entities;
using BaseSource.Infra.Data.Sql.Library.Databases;
using Microsoft.EntityFrameworkCore;

namespace BaseSource.Infra.Data.Sql.Query.Library.Database;

public class DatabaseContextQuery : BaseQueryDbContext
{
    public DatabaseContextQuery(DbContextOptions<DatabaseContextQuery> options)
        : base(options) { }



    public virtual DbSet<Person> People { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
