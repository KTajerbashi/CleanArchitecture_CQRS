using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.ApplicationServices.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;

public class GetPersonByIdHandler : IQueryHandler<GetPersonByIdModel, PersonQuery>
{
    public Task<QueryResult<PersonQuery>> Handle(GetPersonByIdModel request)
    {
        throw new NotImplementedException();
    }
}
