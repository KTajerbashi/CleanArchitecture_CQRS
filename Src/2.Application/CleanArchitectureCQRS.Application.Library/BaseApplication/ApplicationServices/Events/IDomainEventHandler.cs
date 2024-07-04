using CleanArchitectureCQRS.Domain.Library.BaseDomain.Events;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Events;


/// <summary>
/// 
/// </summary>
/// <typeparam name="TDomainEvent"></typeparam>
public interface IDomainEventHandler<TDomainEvent>: INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}