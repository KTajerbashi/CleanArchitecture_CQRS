using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;

namespace CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.ApplicationServices.Queries;
/// <summary>
/// تعریف ساختار مورد نیاز جهت پردازش یک کورئری
/// </summary>
/// <typeparam name="TQuery">نوع کوئری و پارامتر‌های ورودی را تعیین می‌کند</typeparam>
/// <typeparam name="TData">نوع داده‌های بازگشتی را تعیین می‌کند</typeparam>
public interface IQueryHandler<TQuery, TData>
    where TQuery : class, IQuery<TData>
{
    Task<QueryResult<TData>> Handle(TQuery request);
}

