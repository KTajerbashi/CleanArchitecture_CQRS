using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;
using BaseSource.Core.Domain.Aggregates.Store.Card;

namespace BaseSource.Core.Infrastrcuture.SQL.Query.Repositories.Store.Card;

public class CardQueryRepository : QueryRepository<CardEntity, long, QueryDataContext>, ICardQueryRepository
{
    public CardQueryRepository(QueryDataContext context) : base(context)
    {
    }
}