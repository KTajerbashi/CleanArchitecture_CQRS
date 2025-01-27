using BaseSource.Core.Application.Library.BaseApplication.Contracts.Data.Commands;
using BaseSource.Core.Domain.Library.Aggregates.People.Entities;

namespace BaseSource.Core.Application.Library.Aggregates.People.Repositories;

public interface IPersonCommandRepository : ICommandRepository<Person, int>
{
    Task SendEmail();
}
