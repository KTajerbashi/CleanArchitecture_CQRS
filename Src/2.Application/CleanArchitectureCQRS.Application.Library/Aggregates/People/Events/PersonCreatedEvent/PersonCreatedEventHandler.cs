﻿using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Events;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.DomainEvents;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Events.PersonCreatedEvent;

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
            Person person = new Person(notification.FirstName,notification.LastName,$"{notification.FirstName}_{notification.LastName}@mail.com","09021301500");
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