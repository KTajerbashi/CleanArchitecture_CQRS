using BaseSource.Core.Domain.Library.Entities.People.Entities;
using BaseSource.Infra.Data.Sql.Library.Databases;
using Microsoft.EntityFrameworkCore;

namespace BaseSource.Infra.Data.Sql.Query.Library.Database;

public class DatabaseContextQuery : BaseQueryDbContext
{
    public DatabaseContextQuery(DbContextOptions<DatabaseContextQuery> options)
        : base(options) { }



    public virtual DbSet<Person> People => Set<Person>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
