using CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetAllPerson;

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
