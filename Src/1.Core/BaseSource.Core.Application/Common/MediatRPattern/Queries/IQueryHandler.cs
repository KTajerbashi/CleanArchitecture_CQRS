
using BaseSource.Core.Application.Providers;

namespace BaseSource.Core.Application.Common.MediatRPattern.Queries;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : Query<TResponse>
{

}
public abstract class QueryHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
    where TQuery : Query<TResponse>
{
    protected readonly ProviderFactory Factory;
    protected QueryHandler(ProviderFactory factory)
    {
        Factory = factory;
    }
    public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
}