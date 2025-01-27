using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Queries;
using MediatR;

namespace BaseSource.Core.Application.Library.BaseApplication.ApplicationServices.Queries;
/// <summary>
/// تعریف ساختار مورد نیاز جهت پردازش یک کورئری
/// </summary>
/// <typeparam name="TQuery">نوع کوئری و پارامتر‌های ورودی را تعیین می‌کند</typeparam>
/// <typeparam name="TData">نوع داده‌های بازگشتی را تعیین می‌کند</typeparam>
public interface IQueryHandler<TQuery, TData> : IRequestHandler<TQuery, QueryResult<TData>>
    where TQuery : IQuery<TData>
{

}

