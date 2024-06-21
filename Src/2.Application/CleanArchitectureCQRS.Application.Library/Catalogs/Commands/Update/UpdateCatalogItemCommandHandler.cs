using CleanArchitectureCQRS.Application.Library.Base.Application.BaseRepositories;
using CleanArchitectureCQRS.Application.Library.Catalogs.Commands.Repository;
using CleanArchitectureCQRS.Domain.Library.Catalogs.Entities;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.Catalogs.Commands.Update;

public class UpdateCatalogItemCommandHandler : INotificationHandler<UpdateCatalogItemCommand>
{
    private readonly IAggregateRepository<CatalogItem, Guid> _aggregateRepository;
    private readonly ICatalogItemRepository _catalogItemRepository;
    public UpdateCatalogItemCommandHandler(IAggregateRepository<CatalogItem, Guid> aggregateRepository,
        ICatalogItemRepository catalogItemRepository)
    {
        _aggregateRepository = aggregateRepository;
        _catalogItemRepository = catalogItemRepository;
    }

    #region INotificationHandler implementation
    public async Task Handle(UpdateCatalogItemCommand notification, CancellationToken cancellationToken)
    {
        var catalogItem = await _aggregateRepository.RehydreateAsync(notification.CatalogItemId, cancellationToken);

        if (catalogItem == null)
        {
            throw new Exception("Invalide catalog item information");
        }

        catalogItem.Update(notification.CatalogItemId, notification.Name, notification.Description, notification.Price,
            notification.AvailableStock, notification.RestockThreshold, notification.MaxStockThreshold, notification.OnReorder);

        await _aggregateRepository.AppendAsync(catalogItem, cancellationToken);

        // Save data into database

        await _catalogItemRepository.UpdateAsync(catalogItem);


    }

    #endregion
}

