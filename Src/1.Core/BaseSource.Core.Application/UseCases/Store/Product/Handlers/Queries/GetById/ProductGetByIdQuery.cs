using BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;

namespace BaseSource.Core.Application.UseCases.Store.Product.Handlers.Queries.GetById;

public class ProductGetByIdResponse : QueryModel
{
    public string Title { get; set; }
    public string Details { get; set; }
}
public class ProductGetByIdQuery : Query<ProductGetByIdResponse>
{
    public ProductGetByIdQuery(Guid entityId)
    {
        EntityId = entityId;
    }

    public Guid EntityId { get; }
}

public class ProductGetByIdValidator : AbstractValidator<ProductGetByIdQuery>
{
    public ProductGetByIdValidator()
    {

    }
}

public class ProductGetByIdHandler : QueryHandler<ProductGetByIdQuery, ProductGetByIdResponse>
{
    private readonly IProductQueryRepository _repository;
    public ProductGetByIdHandler(ProviderFactory factory, IProductQueryRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<ProductGetByIdResponse> Handle(ProductGetByIdQuery Query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductGetByIdQuery, ProductGetByIdQuery>().ReverseMap();
    }
}