using BaseSource.Core.Domain.Library.Common.Events;
using MediatR;

namespace BaseSource.Core.Application.Library.Common.ApplicationServices.Events;


/// <summary>
/// 
/// </summary>
/// <typeparam name="TDomainEvent"></typeparam>
public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}