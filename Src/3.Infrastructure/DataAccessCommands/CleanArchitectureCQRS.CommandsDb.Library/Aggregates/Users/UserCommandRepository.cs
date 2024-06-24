using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Repositories;
using CleanArchitectureCQRS.CommandsDb.Library.BaseCommandInfrastrcture;
using CleanArchitectureCQRS.CommandsDb.Library.Database;
using CleanArchitectureCQRS.Domain.Library.Aggregates.Users.Entities;

namespace CleanArchitectureCQRS.CommandsDb.Library.Aggregates.Users;

public class UserCommandRepository : 
    BaseCommandRepository<User, DbContextApplicationCommand, int>,
    IUserCommandRepository
{
    public UserCommandRepository(DbContextApplicationCommand dbContext) : base(dbContext)
    {
    }


}
