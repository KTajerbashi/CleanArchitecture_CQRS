using CleanArchitectureCQRS.Application.Library.Aggregates.People.Events.PersonCreatedEvent;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Repositories;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Events;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.DomainEvents;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.Entities;
using CleanArchitectureCQRS.Domain.Library.Aggregates.Users.DomainEvents;
using CleanArchitectureCQRS.Domain.Library.Aggregates.Users.Entities;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.Users.Events.UserCreatedEvent;

public class UserCreatedEventHandler : IDomainEventHandler<UserCreated>
{
    private readonly ILogger<UserCreatedEventHandler> _logger;
    private readonly IUserCommandRepository userCommandRepository;

    public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger, IUserCommandRepository userCommandRepository)
    {
        _logger = logger;
        this.userCommandRepository = userCommandRepository;
    }

    public async Task Handle(UserCreated Event)
    {
        try
        {
            User user = new User(
                Event.FirstName,
                Event.LastName,
                Event.Email,
                Event.UserName,
                Event.Phone
                );
            await userCommandRepository.InsertAsync(user);
            await userCommandRepository.CommitAsync();

            _logger.LogInformation("Handled {Event} in UserCreatedEventHandler", Event.GetType().Name);

            await Task.CompletedTask;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
