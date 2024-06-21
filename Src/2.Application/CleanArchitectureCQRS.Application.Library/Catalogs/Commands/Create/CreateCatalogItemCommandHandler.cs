using CleanArchitectureCQRS.Application.Library.Base.Application.BaseRepositories;
using CleanArchitectureCQRS.Application.Library.Catalogs.Commands.Repository;
using CleanArchitectureCQRS.Domain.Library.Catalogs.Entities;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.Catalogs.Commands.Create;

public class CreateCatalogItemCommandHandler : INotificationHandler<CreateCatalogItemCommand>
{
    private readonly IAggregateRepository<CatalogItem, Guid> _aggregateRepository;
    private readonly ICatalogItemRepository _catalogItemRepository;

    public CreateCatalogItemCommandHandler(IAggregateRepository<CatalogItem, Guid> aggregateRepository,
        ICatalogItemRepository catalogItemRepository)
    {
        _aggregateRepository = aggregateRepository;
        _catalogItemRepository = catalogItemRepository;
    }
    public async Task Handle(CreateCatalogItemCommand notification, CancellationToken cancellationToken)
    {
        // Insert event into eventstore db
        var catalogItem = CatalogItem.Create(notification.Name, notification.Description, notification.Price, notification.AvailableStock,
                notification.RestockThreshold, notification.MaxStockThreshold, notification.OnReorder);
        //await _aggregateRepository.AppendAsync(catalogItem);

        // Save data into database
        //await _catalogItemAggregateRepository.SaveAsync(catalogItem.Events.FirstOrDefault());
        await _catalogItemRepository.AddAsync(catalogItem);

        // Dispatch events to any event/service bus to do next actions
        // We can also register EventStore db Subscription to receive Event Notification
    }

}