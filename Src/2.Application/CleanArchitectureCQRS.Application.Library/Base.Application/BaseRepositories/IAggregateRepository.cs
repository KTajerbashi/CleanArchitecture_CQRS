using CleanArchitectureCQRS.Domain.Library.Base.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Application.Library.Base.Application.BaseRepositories;

public interface IAggregateRepository<TA, TKey> where TA : class, IAggregateRoot<TKey>
{
    // Append events to store in event store database
    Task AppendAsync(TA aggregate, CancellationToken cancellationToken = default);

    // Read all events using aggregate ID
    Task<TA?> RehydreateAsync(TKey aggregateId, CancellationToken cancellationToken = default);

    // Read events as a log and return into a dictionary
    Task<Dictionary<int, object>> ReadEventsAsync(TKey aggregateId, CancellationToken cancellationToken = default);
}