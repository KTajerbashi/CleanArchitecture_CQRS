using BaseSource.Core.Application.UseCases.Store.Product.Repositories.ProductDetail;
using BaseSource.Core.Domain.Aggregates.Store.Product;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Repositories.Store.Product;

public class ProductDetailCommandRepository : CommandRepository<ProductDetailEntity, long, CommandDataContext>, IProductDetailCommandRepository
{
    public ProductDetailCommandRepository(CommandDataContext context) : base(context)
    {
    }
}
