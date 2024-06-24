using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.Data.Commands;
using CleanArchitectureCQRS.Domain.Library.Aggregates.Users.Entities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.Users.Repositories;

public interface IUserCommandRepository : ICommandRepository<User, int>
{
}
