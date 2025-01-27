﻿using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Common;
using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Queries;
using BaseSource.Core.Application.Library.BaseApplication.Utilities;

namespace BaseSource.Core.Application.Library.BaseApplication.ApplicationServices.Queries;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TQuery"></typeparam>
/// <typeparam name="TData"></typeparam>
public abstract class QueryHandler<TQuery, TData> : IQueryHandler<TQuery, TData>
    where TQuery : IQuery<TData>
{
    /// <summary>
    /// 
    /// </summary>
    protected readonly UtilitiesServices UtilitiesServices;

    /// <summary>
    /// 
    /// </summary>
    protected readonly QueryResult<TData> result = new();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    protected virtual Task<QueryResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)
    {
        result._data = data;
        result.Status = status;
        return Task.FromResult(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    protected virtual QueryResult<TData> Result(TData data, ApplicationServiceStatus status)
    {
        result._data = data;
        result.Status = status;
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    protected virtual Task<QueryResult<TData>> ResultAsync(TData data)
    {
        var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
        return ResultAsync(data, status);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    protected virtual QueryResult<TData> Result(TData data)
    {
        var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
        return Result(data, status);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="utilitiesServices"></param>
    public QueryHandler(UtilitiesServices utilitiesServices)
    {
        UtilitiesServices = utilitiesServices;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    protected void AddMessage(string message)
    {
        result.AddMessage(message);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="arguments"></param>
    protected void AddMessage(string message, params string[] arguments)
    {
        result.AddMessage(message);
    }


    public abstract Task<QueryResult<TData>> Handle(TQuery request, CancellationToken cancellationToken);
}
