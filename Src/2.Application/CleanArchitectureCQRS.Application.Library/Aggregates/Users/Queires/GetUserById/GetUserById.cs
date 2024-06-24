using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Repositories;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;
using CleanArchitectureCQRS.Domain.Library.BaseDomain.ValueObjects;
using FluentValidation;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.Users.Queires.GetUserById;

public class UserModel
{
    public Guid BusinessId { get; set; }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

public class GetUserById : IQuery<UserModel>
{
    public int Id { get; set; }
}

public class GetUserByIdValidator : AbstractValidator<GetUserById>
{

}

public class GetUserByIdHandler : QueryHandler<GetUserById, UserModel>
{
    private readonly IUserQueryRepository userQueryRepository;

    public GetUserByIdHandler(UtilitiesServices utilitiesServices, IUserQueryRepository userQueryRepository) : base(utilitiesServices)
    {
        this.userQueryRepository = userQueryRepository;
    }

    public override async Task<QueryResult<UserModel>> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        return await ResultAsync(userQueryRepository.GetUserById(request.Id));
    }
}

