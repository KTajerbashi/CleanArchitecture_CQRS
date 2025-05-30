﻿namespace BaseSource.Core.Domain.Library.Common.Events;

/// <summary>
/// در این مجموعه از 
/// event
/// ها برای تغییر وضعیت و نگهداری تغییرات استفاده می‌شود
/// به منظور انجام اتوماتیک امور مختلف از این اینترفیس به عنوان 
/// marker
/// استفاده می شود
/// </summary>
public interface IDomainEvent : INotification
{
}
