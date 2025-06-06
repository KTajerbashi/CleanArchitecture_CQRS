using BaseSource.Core.Application.Common.RepositoryPatttern;
using BaseSource.Core.Domain.Aggregates.Store.Card;

namespace BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;

public interface ICardQueryRepository: IQueryRepository<CardEntity, long>
{
}

