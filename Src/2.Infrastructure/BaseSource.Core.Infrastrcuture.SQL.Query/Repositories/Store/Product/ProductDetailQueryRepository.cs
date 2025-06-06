using BaseSource.Core.Application.UseCases.Store.Product.Repositories.ProductDetail;
using BaseSource.Core.Domain.Aggregates.Store.Product;

namespace BaseSource.Core.Infrastrcuture.SQL.Query.Repositories.Store.Product;

public class ProductDetailQueryRepository : QueryRepository<ProductDetailEntity, long, QueryDataContext>, IProductDetailQueryRepository
{
    public ProductDetailQueryRepository(QueryDataContext context) : base(context)
    {
    }
}
