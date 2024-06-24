using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Queires.GetUserById;
using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Repositories;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.Users.Queires.GetAllUser;

public class GetAllUsers : IQuery<List<UserModel>>
{
}

public class GetAllUsersValidator : AbstractValidator<GetAllUsers>
{
}

public class GetAllUsersHandler : QueryHandler<GetAllUsers, List<UserModel>>
{
    private readonly IUserQueryRepository userQueryRepository;
    public GetAllUsersHandler(UtilitiesServices utilitiesServices, IUserQueryRepository userQueryRepository) : base(utilitiesServices)
    {
        this.userQueryRepository = userQueryRepository;
    }

    public override async Task<QueryResult<List<UserModel>>> Handle(GetAllUsers request, CancellationToken cancellationToken)
    {
        return await ResultAsync(userQueryRepository.GetAllUsers());
    }
}