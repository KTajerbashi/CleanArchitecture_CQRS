using CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.Data.Queries;

namespace MiniBlog.Core.Contracts.People.Queries
{
    public interface IPersonQueryRepository : IQueryRepository
    {
        public Task<PersonQuery?> ExecuteAsync(GetPersonById query);

    }
}
