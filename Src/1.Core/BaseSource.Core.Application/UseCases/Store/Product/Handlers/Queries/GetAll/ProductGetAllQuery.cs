using BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;

namespace BaseSource.Core.Application.UseCases.Store.Product.Handlers.Queries.GetAll;

public class ProductGetAllResponse : QueryModel
{
    public string Title { get; set; }
    public string Details { get; set; }
}
public class ProductGetAllQuery : Query<List<ProductGetAllResponse>>
{
}

public class ProductGetAllValidator : AbstractValidator<ProductGetAllQuery>
{
    public ProductGetAllValidator()
    {

    }
}

public class ProductGetAllHandler : QueryHandler<ProductGetAllQuery, List<ProductGetAllResponse>>
{
    private readonly IProductQueryRepository _repository;
    public ProductGetAllHandler(ProviderFactory factory, IProductQueryRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<List<ProductGetAllResponse>> Handle(ProductGetAllQuery Query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductGetAllQuery, ProductGetAllQuery>().ReverseMap();
    }
}