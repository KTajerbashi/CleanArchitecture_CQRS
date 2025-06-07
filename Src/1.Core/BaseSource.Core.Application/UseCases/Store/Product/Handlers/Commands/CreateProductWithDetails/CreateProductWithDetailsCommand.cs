

namespace BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.CreateProductWithDetails;

public record CreateProductWithDetailsResponse();

public record ProductDetailModel(string Title,string Value);
public class CreateProductWithDetailsCommand : Command<CreateProductWithDetailsResponse>
{
    public List<ProductDetailModel> ProductDetails { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string CardCode { get; set; }
}
public class CreateProductWithDetailsValidator : AbstractValidator<CreateProductWithDetailsCommand> {
    public CreateProductWithDetailsValidator()
    {
        
    }
}
