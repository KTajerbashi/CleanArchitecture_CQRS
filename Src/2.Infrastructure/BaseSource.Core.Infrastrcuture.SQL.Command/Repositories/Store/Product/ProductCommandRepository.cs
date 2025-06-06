using BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;
using BaseSource.Core.Domain.Aggregates.Store.Product;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Repositories.Store.Product;

public class ProductCommandRepository : CommandRepository<ProductEntity, long, CommandDataContext>, IProductCommandRepository
{
    public ProductCommandRepository(CommandDataContext context) : base(context)
    {
    }
}
