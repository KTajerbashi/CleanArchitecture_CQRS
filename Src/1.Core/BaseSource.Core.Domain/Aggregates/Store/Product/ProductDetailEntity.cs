using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Domain.Aggregates.Store.Product;

[Table("ProductDetails", Schema = "Store")]
public class ProductDetailEntity : Entity
{
    private ProductDetailEntity() { }

    public string Title { get; private set; }
    public string Value { get; private set; }

    public long ProductId { get; private set; }

    [ForeignKey(nameof(ProductId))]
    public virtual ProductEntity Product { get; private set; }

    public ProductDetailEntity(string title, string value)
    {
        Title = title;
        Value = value;
    }
}
