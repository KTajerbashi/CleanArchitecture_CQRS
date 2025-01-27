using BaseSource.Core.Application.Library.Aggregates.People.Queries.GetById;
using BaseSource.Core.Application.Library.BaseApplication.Contracts.Data.Queries;

namespace BaseSource.Core.Application.Library.Aggregates.People.Repositories
{
    public interface IPersonQueryRepository : IQueryRepository
    {
        public PersonQuery GetPersonById(GetPersonById query);
        public List<PersonQuery> GetAllPerson();

    }
}
