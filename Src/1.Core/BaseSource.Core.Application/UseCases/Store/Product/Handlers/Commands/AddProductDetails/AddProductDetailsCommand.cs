using BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;

namespace BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.AddProductDetails;

public record AddProductDetailsResponse(long Id);
public class AddProductDetailsCommand : Command<AddProductDetailsResponse>
{
    public string Title { get; set; }
    public string Value { get; set; }
    public long ProductId { get; set; }
}

public class AddProductDetailsValidator : AbstractValidator<AddProductDetailsCommand>
{
    public AddProductDetailsValidator()
    {

    }
}

public class AddProductDetailsHandler : CommandHandler<AddProductDetailsCommand, AddProductDetailsResponse>
{
    private readonly IProductCommandRepository _repository;
    public AddProductDetailsHandler(ProviderFactory factory, IProductCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override async Task<AddProductDetailsResponse> Handle(AddProductDetailsCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var productEntity = await _repository.GetAsync(command.ProductId);
            productEntity.AddDetail(command.Title, command.Value);
            await _repository.SaveChangesAsync(cancellationToken);
            return new(command.ProductId);
        }
        catch (Exception)
        {

            throw;
        }
    }
}

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<AddProductDetailsCommand, AddProductDetailsCommand>().ReverseMap();
    }
}
