using BaseSource.Core.Application.Library.Aggregates.People.Queries.GetById;
using BaseSource.Core.Application.Library.Aggregates.People.Repositories;
using BaseSource.Core.Application.Library.BaseApplication.ApplicationServices.Queries;
using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Queries;
using BaseSource.Core.Application.Library.BaseApplication.Utilities;

namespace BaseSource.Core.Application.Library.Aggregates.People.Queries.GetAllPerson;

public class GetAllPersonHandler : QueryHandler<GetAllPerson, List<PersonQuery>>
{
    private readonly IPersonQueryRepository personQueryRepository;
    public GetAllPersonHandler(UtilitiesServices utilitiesServices, IPersonQueryRepository personQueryRepository) : base(utilitiesServices)
    {
        this.personQueryRepository = personQueryRepository;
    }

    public override async Task<QueryResult<List<PersonQuery>>> Handle(GetAllPerson request, CancellationToken cancellationToken)
    {
        return await ResultAsync(personQueryRepository.GetAllPerson());
    }
}
