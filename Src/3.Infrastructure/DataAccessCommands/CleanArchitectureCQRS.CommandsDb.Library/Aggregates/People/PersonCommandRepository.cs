using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using CleanArchitectureCQRS.CommandsDb.Library.BaseCommandInfrastrcture;
using CleanArchitectureCQRS.CommandsDb.Library.Database;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.Entities;

namespace CleanArchitectureCQRS.CommandsDb.Library.Aggregates.People;

public class PersonCommandRepository :
        BaseCommandRepository<Person, DbContextApplicationCommand, int>,
        IPersonCommandRepository
{
    public PersonCommandRepository(DbContextApplicationCommand dbContext) : base(dbContext)
    {
    }
}
