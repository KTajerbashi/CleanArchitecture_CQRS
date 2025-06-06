using BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;
using BaseSource.Core.Domain.Aggregates.Store.Product;

namespace BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.Create;

public record ProductCreateResponse(long Id);
public class ProductCreateCommand : Command<ProductCreateResponse>
{
    public string Title { get; set; }
    public string Details { get; set; }
}

public class ProductCreateValidator : AbstractValidator<ProductCreateCommand>
{
    public ProductCreateValidator()
    {

    }
}

public class ProductCreateHandler : CommandHandler<ProductCreateCommand, ProductCreateResponse>
{
    private readonly IProductCommandRepository _repository;
    public ProductCreateHandler(ProviderFactory factory, IProductCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override async Task<ProductCreateResponse> Handle(ProductCreateCommand command, CancellationToken cancellationToken)
    {
        try
        {
            ProductEntity entity = ProductEntity.Create(command.Title,command.Details);
            var result = await _repository.InsertAsync(entity);
            await _repository.SaveChangeAsync(cancellationToken);
            return new ProductCreateResponse(entity.Id);
        }
        catch (Exception ex)
        {
            throw new AppException(ex.Message);
        }
    }
}

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreateCommand, ProductCreateCommand>().ReverseMap();
    }
}