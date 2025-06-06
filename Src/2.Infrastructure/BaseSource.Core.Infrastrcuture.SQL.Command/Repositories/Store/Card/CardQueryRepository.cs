using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;
using BaseSource.Core.Domain.Aggregates.Store.Card;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Repositories.Store.Card;

public class CardCommandRepository : CommandRepository<CardEntity, long, CommandDataContext>, ICardCommandRepository
{
    public CardCommandRepository(CommandDataContext context) : base(context)
    {
    }
}

