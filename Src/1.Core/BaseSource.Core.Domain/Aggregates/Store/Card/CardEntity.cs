using BaseSource.Core.Domain.Aggregates.Store.Card.Events;
using BaseSource.Core.Domain.Aggregates.Store.Product;
using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Domain.Aggregates.Store.Card;

[Table("Cards", Schema = "Store")]
public class CardEntity : AggregateRoot
{
    private readonly List<CardProductEntity> _cardProducts = new();

    private CardEntity() { }

    public string CardCode { get; private set; }

    public virtual IReadOnlyCollection<CardProductEntity> CardProductEntities => _cardProducts.AsReadOnly();

    public static CardEntity Create(string cardCode)
    {
        var entity = new CardEntity
        {
            CardCode = cardCode
        };
        entity.AddEvent(new CardCreatedEvent(entity));
        return entity;
    }

    public void AddProduct(long productId)
    {
        var cardProduct = new CardProductEntity(productId);
        _cardProducts.Add(cardProduct);
        AddEvent(new CardProductAddedEvent(Id, cardProduct.ProductId));
    }
}

