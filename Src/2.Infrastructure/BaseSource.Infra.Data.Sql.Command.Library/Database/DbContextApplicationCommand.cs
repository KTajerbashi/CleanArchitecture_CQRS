using BaseSource.Core.Domain.Library.Aggregates.People.Entities;
using BaseSource.Core.Domain.Library.Aggregates.People.ValueObjects;
using BaseSource.Core.Domain.Library.Aggregates.Products.Entities;
using BaseSource.Infra.Data.Sql.Command.Library.BaseCommandInfrastrcture;
using BaseSource.Infra.Data.Sql.Command.Library.BaseCommandInfrastrcture.Extensions;
using BaseSource.Infra.Data.Sql.Library.ValueConversions;
using Microsoft.EntityFrameworkCore;

namespace BaseSource.Infra.Data.Sql.Command.Library.Database;

public class DbContextApplicationCommand : BaseCommandDbContext
{
    public DbContextApplicationCommand(DbContextOptions<DbContextApplicationCommand> options) : base(options)
    {

    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<FirstName>().HaveConversion<FirstNameConversion>();
        configurationBuilder.Properties<LastName>().HaveConversion<LastNameConversion>();
        configurationBuilder.Properties<UserName>().HaveConversion<UserNameConversion>();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder
            .ConfigurationTables()
            .Seed();
    }

    public virtual DbSet<Person> People { get; set; }
    public virtual DbSet<Product> Products { get; set; }
}
