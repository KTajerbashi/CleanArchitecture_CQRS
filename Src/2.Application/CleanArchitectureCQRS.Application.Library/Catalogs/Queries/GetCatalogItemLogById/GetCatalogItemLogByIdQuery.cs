using MediatR;

namespace CleanArchitectureCQRS.Application.Library.Catalogs.Queries.GetCatalogItemLogById;

public class GetCatalogItemLogByIdQuery : IRequest<List<object>>
{
    public GetCatalogItemLogByIdQuery(Guid catalogItemId)
    {
        CatalogItemId = catalogItemId;
    }

    public Guid CatalogItemId { get; private set; }
}
