using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;

public class GetPersonByIdHandler : QueryHandler<GetPersonById, PersonQuery>
{
    public GetPersonByIdHandler(UtilitiesServices utilitiesServices) : base(utilitiesServices)
    {
    }

    public override Task<QueryResult<PersonQuery>> Handle(GetPersonById request, CancellationToken cancellationToken)
    {
        return ResultAsync(new PersonQuery());
    }
}
