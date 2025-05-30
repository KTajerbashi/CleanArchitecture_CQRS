
namespace BaseSource.Core.Application.Common.MediatRPattern.Queries;

public interface IQuery<TResponse> : IRequest<TResponse>
{ }

public abstract class Query<TResponse> : IQuery<TResponse>
{

}



