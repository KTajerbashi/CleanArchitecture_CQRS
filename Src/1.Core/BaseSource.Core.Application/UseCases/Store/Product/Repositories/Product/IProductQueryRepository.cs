using BaseSource.Core.Domain.Aggregates.Store.Product;

namespace BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;

public interface IProductQueryRepository : IQueryRepository<ProductEntity, long>
{
}
