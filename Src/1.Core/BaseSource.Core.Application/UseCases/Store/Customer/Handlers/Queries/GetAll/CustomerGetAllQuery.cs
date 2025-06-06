using BaseSource.Core.Application.UseCases.Store.Customer.Repositories.Customer;

namespace BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Queries.GetAll;

public class CustomerGetAllResponse : QueryModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
public class CustomerGetAllQuery : Query<List<CustomerGetAllResponse>>
{
}

public class CustomerGetAllValidator : AbstractValidator<CustomerGetAllQuery>
{
    public CustomerGetAllValidator()
    {

    }
}

public class CustomerGetAllHandler : QueryHandler<CustomerGetAllQuery, List<CustomerGetAllResponse>>
{
    private readonly ICustomerQueryRepository _repository;
    public CustomerGetAllHandler(ProviderFactory factory, ICustomerQueryRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<List<CustomerGetAllResponse>> Handle(CustomerGetAllQuery Query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerGetAllQuery, CustomerGetAllQuery>().ReverseMap();
    }
}