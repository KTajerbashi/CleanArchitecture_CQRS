using CleanArchitectureCQRS.Domain.Library.Catalogs.Entities;

namespace CleanArchitectureCQRS.Application.Library.Catalogs.Commands.Repository;

public interface ICatalogItemRepository
{
    Task AddAsync(CatalogItem catalogItem);
    Task UpdateAsync(CatalogItem catalogItem);
}
