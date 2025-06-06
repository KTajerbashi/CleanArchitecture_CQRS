using BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;

namespace BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.Update;

public record ProductUpdateResponse();
public class ProductUpdateCommand : Command<ProductUpdateResponse>
{
    public string Title { get; set; }
    public string Details { get; set; }
}

public class ProductUpdateValidator : AbstractValidator<ProductUpdateCommand>
{
    public ProductUpdateValidator()
    {

    }
}

public class ProductUpdateHandler : CommandHandler<ProductUpdateCommand, ProductUpdateResponse>
{
    private readonly IProductCommandRepository _repository;
    public ProductUpdateHandler(ProviderFactory factory, IProductCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<ProductUpdateResponse> Handle(ProductUpdateCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductUpdateCommand, ProductUpdateCommand>().ReverseMap();
    }
}