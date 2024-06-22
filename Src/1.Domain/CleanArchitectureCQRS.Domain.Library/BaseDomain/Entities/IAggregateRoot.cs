using CleanArchitectureCQRS.Domain.Library.BaseDomain.Events;

namespace CleanArchitectureCQRS.Domain.Library.BaseDomain.Entities;

public interface IAggregateRoot
{
    /// <summary>
    /// رخداد های موجودیت را حذف میکند 
    /// </summary>
    void ClearEvents();
    /// <summary>
    /// تمام رویداد های که روی موجودیت اتفاق می افتد را نگه میدارد
    /// </summary>
    /// <returns></returns>
    IEnumerable<IDomainEvent> GetEvents();
}
