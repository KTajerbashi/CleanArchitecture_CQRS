using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Common;

namespace CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;

/// <summary>
/// نتیجه یک کوئری را بازگشت می‌دهد
/// </summary>
/// <typeparam name="TData"></typeparam>
public sealed class QueryResult<TData> : ApplicationServiceResult
{
    public TData? _data;
    public TData? Data
    {
        get
        {
            return _data;
        }
    }
}

