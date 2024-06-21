using CleanArchitectureCQRS.Domain.Library.Base.Domain.Events;
using CleanArchitectureCQRS.Domain.Library.Catalogs.Entities;

namespace CleanArchitectureCQRS.Domain.Library.Catalogs.Events;

/// <summary>
/// Catalog item created event
/// </summary>
public class CatalogItemDeleted : BaseDomainEvent<CatalogItem, Guid>
{

    private CatalogItemDeleted()
    {

    }
    public CatalogItemDeleted(CatalogItem catalogItem) : base(catalogItem)
    {
        IsDeleted = catalogItem.IsDeleted;
    }
    public bool IsDeleted { get; private set; }

}