using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Repositories;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.ValueObjects;
using CleanArchitectureCQRS.Domain.Library.Aggregates.Users.Entities;
using FluentValidation;
using MediatR;

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
    private readonly IPublisher publisher;
    public CreateUserHandler(UtilitiesServices utilitiesServices, IUserCommandRepository userCommandRepository, IPublisher publisher) : base(utilitiesServices)
    {
        this.userCommandRepository = userCommandRepository;
        this.publisher = publisher;
    }

    public override async Task<CommandResult<Guid>> Handle(CreateUser request, CancellationToken cancellationToken)
    {
        userCommandRepository.BeginTransaction();
        try
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
            userCommandRepository.CommitTransaction();
            var Events = entity.GetEvents().ToList();
            //Events.ForEach(async @event => await publisher.Publish(@event));
            return Ok(entity.BusinessId.Value);
        }
        catch (Exception)
        {
            userCommandRepository.RollbackTransaction();
            throw;
        }


    }
}