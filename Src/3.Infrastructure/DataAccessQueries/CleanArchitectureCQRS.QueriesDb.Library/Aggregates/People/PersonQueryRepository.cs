﻿using CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using CleanArchitectureCQRS.QueriesDb.Library.BaseQueriesInfrastrcture;
using CleanArchitectureCQRS.QueriesDb.Library.Database;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.QueriesDb.Library.Aggregates.People;

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
