using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;

namespace CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Queries;

/// <summary>
/// تعریف ساختار الگوی Mediator جهت اتصال ساده کوئری‌ها به هندلر‌ها
/// </summary>
public interface IQueryDispatcher
{
    Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>;
}


/// Query Executed      query execute and can run 
/// Command Sending     can one person handled so send for that
/// Event Publish       can has many Handler 