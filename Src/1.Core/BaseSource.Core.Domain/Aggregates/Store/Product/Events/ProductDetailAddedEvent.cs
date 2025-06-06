namespace BaseSource.Core.Domain.Aggregates.Store.Product.Events;

public class ProductDetailAddedEvent(EntityId EntityId, ProductDetailEntity ProductDetail) : DomainEvent
{
    public EntityId ProductId => EntityId;
    public ProductDetailEntity Detail => ProductDetail;
}
