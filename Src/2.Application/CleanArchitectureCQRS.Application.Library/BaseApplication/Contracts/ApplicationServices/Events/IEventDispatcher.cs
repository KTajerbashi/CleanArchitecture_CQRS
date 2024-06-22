using CleanArchitectureCQRS.Domain.Library.BaseDomain.Events;

namespace CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.ApplicationServices.Events;
/// <summary>
/// این جهت پیاده سازی الگوی 
/// Mediate R 
/// میباشد
/// </summary>
public interface IEventDispatcher
{
    Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent;
}