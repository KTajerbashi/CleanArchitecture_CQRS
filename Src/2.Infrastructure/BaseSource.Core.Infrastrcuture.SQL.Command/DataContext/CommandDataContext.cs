using BaseSource.Core.Domain.Aggregates.Store.Card;
using BaseSource.Core.Domain.Aggregates.Store.Customer;
using BaseSource.Core.Domain.Aggregates.Store.Product;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.DataContext;

public class CommandDataContext : BaseCommandDataContext
{
    public CommandDataContext()
    {
    }

    public CommandDataContext(DbContextOptions<CommandDataContext> options) : base(options)
    {
    }



    public virtual DbSet<ProductEntity> ProductEntities => Set<ProductEntity>();
    public virtual DbSet<ProductDetailEntity> ProductDetailEntities => Set<ProductDetailEntity>();

    public virtual DbSet<CardEntity> CardEntities => Set<CardEntity>();
    public virtual DbSet<CardProductEntity> CardProductEntities => Set<CardProductEntity>();

    public virtual DbSet<CustomerEntity> CustomerEntities => Set<CustomerEntity>();
    public virtual DbSet<CustomerAddressEntity> CustomerAddressEntities => Set<CustomerAddressEntity>();

}
