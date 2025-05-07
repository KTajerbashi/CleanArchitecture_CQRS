using BaseSource.Core.Application.Library.Aggregates.People.Queries.GetById;
using BaseSource.Core.Application.Library.Aggregates.People.Repositories;

namespace BaseSource.Core.Application.Library.Aggregates.People.Queries.GetAllPerson;

public class GetAllPersonHandler : QueryHandler<GetAllPerson, List<PersonQuery>>
{
    private readonly IPersonQueryRepository _repository;

    public GetAllPersonHandler(ProviderUtilities providerUtilities, IPersonQueryRepository repository) : base(providerUtilities)
    {
        _repository = repository;
    }

    public override Task<QueryResult<List<PersonQuery>>> Handle(GetAllPerson request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
