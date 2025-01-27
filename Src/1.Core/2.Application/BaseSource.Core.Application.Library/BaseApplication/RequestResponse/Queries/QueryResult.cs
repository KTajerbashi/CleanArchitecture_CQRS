using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Common;
using MediatR;

namespace BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Queries;

/// <summary>
/// نتیجه یک کوئری را بازگشت می‌دهد
/// </summary>
/// <typeparam name="TData"></typeparam>
public sealed class QueryResult<TData>
    : ApplicationServiceResult, IRequest<TData>
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

