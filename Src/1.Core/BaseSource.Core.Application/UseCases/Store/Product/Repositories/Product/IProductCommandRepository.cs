using BaseSource.Core.Domain.Aggregates.Store.Product;

namespace BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;

public interface IProductCommandRepository : ICommandRepository<ProductEntity, long>
{
}
