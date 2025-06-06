using BaseSource.Core.Application.UseCases.Store.Card.Repositories.CardProduct;
using BaseSource.Core.Domain.Aggregates.Store.Card;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Repositories.Store.Card;

public class CardProductCommandRepository : CommandRepository<CardProductEntity, long, CommandDataContext>, ICardProductCommandRepository
{
    public CardProductCommandRepository(CommandDataContext context) : base(context)
    {
    }
}

