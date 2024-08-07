using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.Data.Commands;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.Entities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;

public interface IPersonCommandRepository : ICommandRepository<Person, int>
{
    Task SendEmail();
}
