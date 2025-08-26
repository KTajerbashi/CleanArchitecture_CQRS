using BaseSource.Core.Domain.Aggregates.Store.Product.Events;
using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Domain.Aggregates.Store.Product;

[Table("Products", Schema = "Store")]
public class ProductEntity : Entity
{
    private List<ProductDetailEntity> _productDetails = new();

    private ProductEntity() { }

    public string Title { get; private set; }
    public string Details { get; private set; }

    public virtual IReadOnlyCollection<ProductDetailEntity> ProductDetails => _productDetails.AsReadOnly();

    public static ProductEntity Create(string title, string details)
    {
        var product = new ProductEntity
        {
            Title = title,
            Details = details
        };
        return product;
    }

    public void AddDetail(string title, string value)
    {
        var detail = new ProductDetailEntity(title, value);
        _productDetails.Add(detail);
    }
}

