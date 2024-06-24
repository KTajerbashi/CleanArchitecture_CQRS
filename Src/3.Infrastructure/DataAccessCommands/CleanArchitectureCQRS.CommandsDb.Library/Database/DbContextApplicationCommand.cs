using CleanArchitectureCQRS.CommandsDb.Library.BaseCommandInfrastrcture;
using CleanArchitectureCQRS.CommandsDb.Library.BaseCommandInfrastrcture.ValueConversions;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.Entities;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.ValueObjects;
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
    }
    public DbSet<Person> People { get; set; }
}
