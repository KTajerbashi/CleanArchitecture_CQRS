using BaseSource.Core.Application.Common.RepositoryPatttern;
using BaseSource.Core.Application.Common.ServicePattern;
using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Infrastrcuture.SQL.Query.Common.ServicePattern;

public abstract class EntityQueryService<TEntity, TId> : IEntityQueryService<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected readonly IQueryRepository<TEntity, TId> Repository;
    protected EntityQueryService(IQueryRepository<TEntity, TId> repository)
    {
        Repository = repository;
    }
}