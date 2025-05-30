using BaseSource.Core.Application.Library.Common.Contracts.Data.Commands;
using BaseSource.Core.Domain.Library.Entities.People.Entities;

namespace BaseSource.Core.Application.Library.Aggregates.People.Repositories;

public interface IPersonCommandRepository : ICommandRepository<Person, int>
{
    Task SendEmail();
}
