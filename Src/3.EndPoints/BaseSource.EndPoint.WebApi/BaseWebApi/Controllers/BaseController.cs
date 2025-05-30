using BaseSource.Core.Application.Library.Common.RequestResponse.Commands;
using BaseSource.Core.Application.Library.Common.RequestResponse.Common;
using BaseSource.Core.Application.Library.Common.RequestResponse.Queries;
using BaseSource.Core.Application.Library.Providers;
using BaseSource.EndPoint.WebApi.HostExtensions.Providers.HttpAccessor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BaseSource.EndPoint.WebApi.BaseWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : Controller
{
    protected readonly IMediator Mediator;

    protected BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }

    protected ProviderUtilities ApplicationContext => HttpContext.ApplicationContext();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TData"></typeparam>
    /// <param name="command"></param>
    /// <returns></returns>
    protected virtual async Task<IActionResult> Create<TCommand, TData>(TCommand command)
        where TCommand : ICommand<TData>
    {
        var result = await Mediator.Send(command);
        if (result.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode((int)HttpStatusCode.OK, result.Data);
        }
        else if (result.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode((int)HttpStatusCode.NotFound, command);
        }
        return BadRequest(result.Messages);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TData"></typeparam>
    /// <param name="command"></param>
    /// <returns></returns>
    protected async Task<IActionResult> Edit<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>
    {
        var result = await Mediator.Send(command);
        if (result.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode((int)HttpStatusCode.OK, result.Data);
        }
        else if (result.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode((int)HttpStatusCode.NotFound, command);
        }
        return BadRequest(result.Messages);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TData"></typeparam>
    /// <param name="command"></param>
    /// <returns></returns>
    protected async Task<IActionResult> Delete<TCommand, TData>(TCommand command) where TCommand : ICommand<TData>
    {
        var result = await Mediator.Send(command);
        if (result.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode((int)HttpStatusCode.OK, result.Data);
        }
        else if (result.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode((int)HttpStatusCode.NotFound, command);
        }
        return BadRequest(result.Messages);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TData"></typeparam>
    /// <param name="command"></param>
    /// <returns></returns>
    protected async Task<IActionResult> GetById<TQuery, TData>(TQuery query) where TQuery : IQuery<TData>
    {
        var result = await Mediator.Send(query);
        if (result.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode((int)HttpStatusCode.OK, result.Data);
        }
        else if (result.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode((int)HttpStatusCode.NotFound, query);
        }
        return BadRequest(result.Messages);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TData"></typeparam>
    /// <param name="command"></param>
    /// <returns></returns>
    protected async Task<IActionResult> Get<TQuery, TData>(TQuery query) where TQuery : IQuery<TData>
    {
        var result = await Mediator.Send(query);
        if (result.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode((int)HttpStatusCode.OK, result.Data);
        }
        else if (result.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode((int)HttpStatusCode.NotFound, query);
        }
        return BadRequest(result.Messages);
    }

    protected async Task<IActionResult> ReturnResponse<TModel>(TModel model)
    {
        return await Task.FromResult(Ok(model));
    }
}
