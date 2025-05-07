using BaseSource.Core.Application.Library.Aggregates.People.Repositories;
using BaseSource.Core.Application.Library.Common.ApplicationServices.Events;
using BaseSource.Core.Domain.Library.Entities.People.DomainEvents;
using BaseSource.Core.Domain.Library.Entities.People.Entities;
using Microsoft.Extensions.Logging;

namespace BaseSource.Core.Application.Library.Aggregates.People.Events.PersonCreatedEvent;

public class PersonCreatedHandler : IDomainEventHandler<PersonCreated>
{
    private readonly ILogger<PersonCreatedHandler> _logger;
    private readonly IPersonCommandRepository personCommandRepository;

    public PersonCreatedHandler(ILogger<PersonCreatedHandler> logger, IPersonCommandRepository personCommandRepository)
    {
        _logger = logger;
        this.personCommandRepository = personCommandRepository;
    }


    public async Task Handle(PersonCreated notification, CancellationToken cancellationToken)
    {
        try
        {
            Person person = new Person(
                notification.FirstName,
                notification.LastName,
                $"{notification.FirstName}_{notification.LastName}@mail.com",
                notification.UserName,
                "09021301500");
            await personCommandRepository.InsertAsync(person);
            await personCommandRepository.CommitAsync();

            _logger.LogInformation("Handled {Event} in BlogCreatedHandler", notification.GetType().Name);

            await Task.CompletedTask;
        }
        catch (Exception)
        {

            throw;
        }
    }
}