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
    private readonly IPersonCommandRepository personCommandRepository;

    public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger, IPersonCommandRepository personCommandRepository)
    {
        _logger = logger;
        this.personCommandRepository = personCommandRepository;
    }


    public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
        personCommandRepository.BeginTransaction();
        try
        {
            Person user = new Person(
                notification.FirstName,
                notification.LastName,
                notification.Email,
                notification.Phone
                );
            await personCommandRepository.InsertAsync(user);
            await personCommandRepository.CommitAsync();

            _logger.LogInformation("Handled {Event} in UserCreatedEventHandler", notification.GetType().Name);
            await Task.CompletedTask;
            personCommandRepository.CommitTransaction();
        }
        catch (Exception)
        {

            personCommandRepository.RollbackTransaction();
            throw;
        }
    }
}
