using BaseSource.Core.Domain.Aggregates.Store.Card.Events;
using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Domain.Aggregates.Store.Card;

[Table("Cards", Schema = "Store")]
public class CardEntity : Entity
{

    private CardEntity() { }

    public string CardCode { get; private set; }

    private List<CardProductEntity> _cardProducts = new();
    public virtual IReadOnlyCollection<CardProductEntity> CardProductEntities => _cardProducts;

    public static CardEntity Create(string cardCode)
    {
        var entity = new CardEntity
        {
            CardCode = cardCode
        };
        return entity;
    }

    public void AddProduct(long productId)
    {
        var cardProduct = new CardProductEntity(productId);
        _cardProducts.Add(cardProduct);
    }
}

