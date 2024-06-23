using CleanArchitectureCQRS.Domain.Library.BaseDomain.Events;

namespace CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Events;


/// <summary>
/// 
/// </summary>
/// <typeparam name="TDomainEvent"></typeparam>
public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent Event);
}