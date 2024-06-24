using CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using CleanArchitectureCQRS.QueriesDb.Library.BaseQueriesInfrastrcture;
using CleanArchitectureCQRS.QueriesDb.Library.Database;
using Microsoft.EntityFrameworkCore;

namespace MiniBlog.Infrastructure.Data.Sql.Queries.People;

public class PersonQueryRepository : BaseQueryRepository<DbContextApplicationQueries>, IPersonQueryRepository
{
    public PersonQueryRepository(DbContextApplicationQueries dbContext) : base(dbContext)
    {
    }

    public async Task<PersonQuery?> ExecuteAsync(GetPersonById query)
    {
        var result =  await _dbContext.People.Select(item => new PersonQuery()
        {
            Id = item.Id,
            FirstName = item.FirstName.Value,
            LastName = item.LastName.Value
        }).FirstOrDefaultAsync(code => code.Id.Equals(query.PersonId));
        return result;
    }
}
