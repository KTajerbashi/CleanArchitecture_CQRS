using CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.Data.Queries;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories
{
    public interface IPersonQueryRepository : IQueryRepository
    {
        public PersonQuery GetPersonById(GetPersonById query);
        public List<PersonQuery> GetAllPerson();

    }
}
