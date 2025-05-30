using BaseSource.Core.Application.Library.Aggregates.People.Repositories;
using BaseSource.Core.Application.Library.Common.ApplicationServices.Queries;
using BaseSource.Core.Application.Library.Common.RequestResponse.Queries;

namespace BaseSource.Core.Application.Library.Aggregates.People.Queries.GetById;

public class GetPersonByIdHandler : QueryHandler<GetPersonById, PersonQuery>
{
    private readonly IPersonQueryRepository _repository;

    public GetPersonByIdHandler(ProviderUtilities providerUtilities, IPersonQueryRepository repository) : base(providerUtilities)
    {
        _repository = repository;
    }

    public override Task<QueryResult<PersonQuery>> Handle(GetPersonById request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
