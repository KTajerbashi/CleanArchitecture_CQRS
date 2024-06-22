using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.Data.Commands;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.Entities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands;

public interface IPersonCommandRepository : ICommandRepository<Person, int>
{
}
