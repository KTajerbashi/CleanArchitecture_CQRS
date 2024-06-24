using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Repositories;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.ValueObjects;
using CleanArchitectureCQRS.Domain.Library.Aggregates.Users.Entities;
using FluentValidation;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.Users.Commands.CreateUser;

public class CreateUser : ICommand<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
public class CreateUserValidator : AbstractValidator<CreateUser>
{
    public CreateUserValidator()
    {

    }
}
public class CreateUserHandler : CommandHandler<CreateUser, Guid>
{
    private readonly IUserCommandRepository userCommandRepository;
    public CreateUserHandler(UtilitiesServices utilitiesServices, IUserCommandRepository userCommandRepository) : base(utilitiesServices)
    {
        this.userCommandRepository = userCommandRepository;
    }

    public override async Task<CommandResult<Guid>> Handle(CreateUser request, CancellationToken cancellationToken)
    {
        var entity = new User(
            request.FirstName,
            request.LastName,
            request.Email,
            request.UserName,
            request.Phone
            );
        entity.ChangeFirstName(request.FirstName);
        entity.ChangeUserName(request.UserName);
        userCommandRepository.Insert(entity);
        await userCommandRepository.CommitAsync();
        return Ok(entity.BusinessId.Value);
    }
}