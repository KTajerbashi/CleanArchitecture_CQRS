namespace BaseSource.Core.Domain.Aggregates.Store.Product.Events;

public class ProductCreatedEvent : DomainEvent
{
    public ProductEntity Product { get; }

    public ProductCreatedEvent(ProductEntity product)
    {
        Product = product;
    }
}
