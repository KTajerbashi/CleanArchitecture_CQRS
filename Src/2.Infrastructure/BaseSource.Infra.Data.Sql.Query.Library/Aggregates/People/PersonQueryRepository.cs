using BaseSource.Core.Application.Library.Aggregates.People.Queries.GetById;
using BaseSource.Core.Application.Library.Aggregates.People.Repositories;
using BaseSource.Infra.Data.Sql.Query.Library.BaseQueriesInfrastrcture;
using BaseSource.Infra.Data.Sql.Query.Library.Database;

namespace BaseSource.Infra.Data.Sql.Query.Library.Aggregates.People;

public class PersonQueryRepository : BaseQueryRepository<DbContextApplicationQuery>, IPersonQueryRepository
{
    public PersonQueryRepository(DbContextApplicationQuery dbContext) : base(dbContext)
    {
    }

    public List<PersonQuery> GetAllPerson()
    {
        var result =  _dbContext.People.Select(item => new PersonQuery()
        {
            Id = item.Id,
            FirstName = item.FirstName.Value,
            LastName = item.LastName.Value
        }).ToList();
        return result;
    }
    public PersonQuery GetPersonById(GetPersonById query)
    {
        var result =  _dbContext.People.Select(item => new PersonQuery()
        {
            Id = item.Id,
            FirstName = item.FirstName.Value,
            LastName = item.LastName.Value
        }).FirstOrDefault(code => code.Id.Equals(query.PersonId));
        return result;
    }
}
