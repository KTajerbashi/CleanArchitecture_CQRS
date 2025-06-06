using BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;

namespace BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.Delete;

public record ProductDeleteResponse();
public class ProductDeleteCommand : Command<ProductDeleteResponse>
{
    public ProductDeleteCommand(Guid entityId)
    {
        EntityId = entityId;
    }

    public Guid EntityId { get; }
}

public class ProductDeleteValidator : AbstractValidator<ProductDeleteCommand>
{
    public ProductDeleteValidator()
    {

    }
}

public class ProductDeleteHandler : CommandHandler<ProductDeleteCommand, ProductDeleteResponse>
{
    private readonly IProductCommandRepository _repository;
    public ProductDeleteHandler(ProviderFactory factory, IProductCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<ProductDeleteResponse> Handle(ProductDeleteCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDeleteCommand, ProductDeleteCommand>().ReverseMap();
    }
}