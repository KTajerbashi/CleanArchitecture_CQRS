using MediatR;

namespace BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Queries;

/// <summary>
/// اینترفیسی جهت استفاده به عنوان مارکر برای کلاس‌هایی که پارامتر‌های ورودی را برای جستجو تعیین می‌کنند!
/// </summary>
/// <typeparam name="TData">نوع بازگشتی را تعیین می‌کند</typeparam>
public interface IQuery<TData> : IRequest<QueryResult<TData>>
{
}

