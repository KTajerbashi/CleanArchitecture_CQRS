using BaseSource.Core.Domain.Aggregates.Store.Product;

namespace BaseSource.Core.Application.UseCases.Store.Product.Repositories.ProductDetail;

public interface IProductDetailQueryRepository : IQueryRepository<ProductDetailEntity, long>
{
}
