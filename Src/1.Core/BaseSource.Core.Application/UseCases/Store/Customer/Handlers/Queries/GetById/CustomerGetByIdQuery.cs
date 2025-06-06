using BaseSource.Core.Application.UseCases.Store.Customer.Repositories.Customer;

namespace BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Queries.GetById;

public class CustomerGetByIdResponse : QueryModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
public class CustomerGetByIdQuery : Query<CustomerGetByIdResponse>
{
    public CustomerGetByIdQuery(Guid entityId)
    {
        EntityId = entityId;
    }

    public Guid EntityId { get; }
}

public class CustomerGetByIdValidator : AbstractValidator<CustomerGetByIdQuery>
{
    public CustomerGetByIdValidator()
    {

    }
}

public class CustomerGetByIdHandler : QueryHandler<CustomerGetByIdQuery, CustomerGetByIdResponse>
{
    private readonly ICustomerQueryRepository _repository;
    public CustomerGetByIdHandler(ProviderFactory factory, ICustomerQueryRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<CustomerGetByIdResponse> Handle(CustomerGetByIdQuery Query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerGetByIdQuery, CustomerGetByIdQuery>().ReverseMap();
    }
}
