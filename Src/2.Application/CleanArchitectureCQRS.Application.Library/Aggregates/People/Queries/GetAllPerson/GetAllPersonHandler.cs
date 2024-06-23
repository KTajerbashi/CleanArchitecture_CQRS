using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetAllPerson;

public class GetAllPersonHandler : QueryHandler<GetAllPerson, int>
{
    public GetAllPersonHandler(UtilitiesServices utilitiesServices) : base(utilitiesServices)
    {
    }

    public override Task<QueryResult<int>> Handle(GetAllPerson request, CancellationToken cancellationToken)
    {
        return ResultAsync(10);
    }
}
