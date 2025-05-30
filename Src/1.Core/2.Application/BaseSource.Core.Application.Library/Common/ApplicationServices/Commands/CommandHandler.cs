﻿using BaseSource.Core.Application.Library.Common.RequestResponse.Common;
using BaseSource.Core.Application.Library.Providers;
using MediatR;

namespace BaseSource.Core.Application.Library.Common.ApplicationServices.Commands;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TData"></typeparam>
public abstract class CommandHandler<TCommand, TData> : ICommandHandler<TCommand, TData>
    where TCommand : ICommand<TData>
{
    /// <summary>
    /// این سرویس خدمات است موارد مورد نیاز است
    /// </summary>
    protected readonly ProviderUtilities ProviderUtilities;

    /// <summary>
    /// چون کاماند هندلر خروجی ازین جنس است پس ما یک نمونه میسازیم
    /// خروجی تمام متد های هندلر ازین جنس است
    /// </summary>
    protected readonly CommandResult<TData> result = new();


    public CommandHandler(ProviderUtilities providerUtilities)
    {
        ProviderUtilities = providerUtilities;
    }

    /// <summary>
    /// این متدی است که توسعه دهنده دستور را ارسال میکند جهت اجرا شدن
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public abstract Task<CommandResult<TData>> Handle(TCommand request, CancellationToken cancellationToken);

    /// <summary>
    /// درصورتیکه خروجی هندل خروجی مورد نظر بود این متد را پاس میدهیم
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    protected virtual Task<CommandResult<TData>> OkAsync(TData data)
    {
        result._data = data;
        result.Status = ApplicationServiceStatus.Ok;
        return Task.FromResult(result);
    }

    /// <summary>
    /// درصورتیکه خروجی هندل خروجی مورد نظر بود این متد را پاس میدهیم
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    protected virtual CommandResult<TData> Ok(TData data)
    {
        result._data = data;
        result.Status = ApplicationServiceStatus.Ok;
        return result;
    }

    /// <summary>
    /// این متد مانند اوکی است اما داده و خروجی را خودش ست میکند و ارسال میکند
    /// </summary>
    /// <param name="data"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    protected virtual Task<CommandResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)
    {
        result._data = data;
        result.Status = status;
        return Task.FromResult(result);
    }

    /// <summary>
    /// این متد مانند اوکی است اما داده و خروجی را خودش ست میکند و ارسال میکند
    /// </summary>
    /// <param name="data"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    protected virtual CommandResult<TData> Result(TData data, ApplicationServiceStatus status)
    {
        result._data = data;
        result.Status = status;
        return result;
    }

    /// <summary>
    /// ایجاد پیام برای خروجی
    /// و استفاده از مترجم
    /// </summary>
    /// <param name="message"></param>
    protected void AddMessage(string message)
    {
        result.AddMessage(message);
    }

    /// <summary>
    /// جهت چند زبانه کردن پیام ها
    /// استفاده از مترجم
    /// </summary>
    /// <param name="message"></param>
    /// <param name="arguments"></param>
    protected void AddMessage(string message, params string[] arguments)
    {
        result.AddMessage(message);
    }

}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TCommand"></typeparam>
public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
{


    protected readonly ProviderUtilities ProviderUtilities;
    protected readonly CommandResult result = new();

    public CommandHandler(ProviderUtilities providerUtilities)
    {
        ProviderUtilities = providerUtilities;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected virtual Task<CommandResult> OkAsync()
    {
        result.Status = ApplicationServiceStatus.Ok;
        return Task.FromResult(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected virtual CommandResult Ok()
    {
        result.Status = ApplicationServiceStatus.Ok;
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    protected virtual Task<CommandResult> ResultAsync(ApplicationServiceStatus status)
    {
        result.Status = status;
        return Task.FromResult(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    protected virtual CommandResult Result(ApplicationServiceStatus status)
    {
        result.Status = status;
        return result;
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

    public abstract Task Handle(TCommand request, CancellationToken cancellationToken);
}

