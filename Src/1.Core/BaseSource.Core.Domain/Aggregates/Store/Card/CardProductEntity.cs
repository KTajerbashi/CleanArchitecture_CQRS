using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Domain.Aggregates.Store.Card;

[Table("CardProducts", Schema = "Store")]
public class CardProductEntity : Entity
{
    private CardProductEntity() { }

    public long ProductId { get; private set; }

    public long CardId { get; private set; }

    [ForeignKey(nameof(CardId))]
    public virtual CardEntity CardEntity { get; private set; }

    public CardProductEntity(long productId)
    {
        ProductId = productId;
    }
}
