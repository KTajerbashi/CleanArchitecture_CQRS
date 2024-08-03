﻿using CleanArchitectureCQRS.Domain.Library.BaseDomain.Events;

namespace CleanArchitectureCQRS.Domain.Library.Aggregates.People.DomainEvents;

public record PersonCreated(
        Guid BusinessId,
        string FirstName,
        string LastName,
        string Email,
        string UserName,
        string Phone
        ) : IDomainEvent;
