namespace BaseSource.Core.Domain.Aggregates.Store.Card.Events;

public class CardCreatedEvent : DomainEvent
{
    public CardEntity Card { get; }

    public CardCreatedEvent(CardEntity card)
    {
        Card = card;
    }
}
