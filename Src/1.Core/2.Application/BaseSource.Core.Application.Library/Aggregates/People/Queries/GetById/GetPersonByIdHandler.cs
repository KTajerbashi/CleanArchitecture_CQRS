using BaseSource.Core.Application.Library.Aggregates.People.Repositories;
using BaseSource.Core.Application.Library.BaseApplication.ApplicationServices.Queries;
using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Queries;
using BaseSource.Core.Application.Library.BaseApplication.Utilities;

namespace BaseSource.Core.Application.Library.Aggregates.People.Queries.GetById;

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
