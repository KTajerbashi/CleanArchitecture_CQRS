namespace BaseSource.Core.Domain.Aggregates.Store.Card.Events;

public class CardProductAddedEvent : DomainEvent
{
    public long CardId { get; }
    public long ProductId { get; }

    public CardProductAddedEvent(long cardId, long productId)
    {
        CardId = cardId;
        ProductId = productId;
    }
}
