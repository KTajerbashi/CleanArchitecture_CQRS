using BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;
using BaseSource.Core.Domain.Aggregates.Store.Product;

namespace BaseSource.Core.Infrastrcuture.SQL.Query.Repositories.Store.Product;

public class ProductQueryRepository : QueryRepository<ProductEntity, long, QueryDataContext>, IProductQueryRepository
{
    public ProductQueryRepository(QueryDataContext context) : base(context)
    {
    }
}
