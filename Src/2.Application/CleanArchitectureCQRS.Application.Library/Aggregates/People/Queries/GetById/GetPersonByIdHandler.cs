using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Common;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;

public class GetPersonByIdHandler : QueryHandler<GetPersonById, PersonQuery>
{
    private readonly IPersonQueryRepository personQueryRepository;
    public GetPersonByIdHandler(UtilitiesServices utilitiesServices, IPersonQueryRepository personQueryRepository) : base(utilitiesServices)
    {
        this.personQueryRepository = personQueryRepository;
    }

    public override Task<QueryResult<PersonQuery>> Handle(GetPersonById request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
