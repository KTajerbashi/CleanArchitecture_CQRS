using BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;

namespace BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.RemoveProductDetails;

public record RemoveProductDetailsResponse();
public class RemoveProductDetailsCommand : Command<RemoveProductDetailsResponse>
{
    public RemoveProductDetailsCommand(Guid entityId)
    {
        EntityId = entityId;
    }
    public Guid EntityId { get; }
}

public class RemoveProductDetailsValidator : AbstractValidator<RemoveProductDetailsCommand>
{
    public RemoveProductDetailsValidator()
    {

    }
}

public class RemoveProductDetailsHandler : CommandHandler<RemoveProductDetailsCommand, RemoveProductDetailsResponse>
{
    private readonly IProductCommandRepository _repository;
    public RemoveProductDetailsHandler(ProviderFactory factory, IProductCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<RemoveProductDetailsResponse> Handle(RemoveProductDetailsCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<RemoveProductDetailsCommand, RemoveProductDetailsCommand>().ReverseMap();
    }
}
