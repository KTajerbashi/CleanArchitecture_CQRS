using CleanArchitectureCQRS.CommandsDb.Library.BaseCommandInfrastrcture;
using CleanArchitectureCQRS.CommandsDb.Library.BaseCommandInfrastrcture.Extensions;
using CleanArchitectureCQRS.ContextDatabase.Library.ValueConversions;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.Entities;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.ValueObjects;
using CleanArchitectureCQRS.Domain.Library.Aggregates.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.CommandsDb.Library.Database;

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
