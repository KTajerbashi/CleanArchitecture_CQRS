using CleanArchitectureCQRS.Application.Library.Base.Application.BaseRepositories;
using CleanArchitectureCQRS.Domain.Library.Catalogs.Entities;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.Catalogs.Queries.GetCatalogItemLogById;

public class GetCatalogItemLogByIdQueryHandler : IRequestHandler<GetCatalogItemLogByIdQuery, List<object>>
{
    private readonly IAggregateRepository<CatalogItem, Guid> _aggregateRepository;

    public GetCatalogItemLogByIdQueryHandler(IAggregateRepository<CatalogItem, Guid> aggregateRepository)
    {
        _aggregateRepository = aggregateRepository;
    }

    public async Task<List<object>> Handle(GetCatalogItemLogByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _aggregateRepository.ReadEventsAsync(request.CatalogItemId, cancellationToken);
        return data.Values.ToList();
    }
}