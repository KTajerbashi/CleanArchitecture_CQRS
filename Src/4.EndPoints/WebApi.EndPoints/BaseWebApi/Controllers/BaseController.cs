using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Common;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.EndPoints.HostExtensions.Providers.HttpAccessor;

namespace WebApi.EndPoints.BaseWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : Controller
{
    protected readonly IMediator Mediator;

    protected BaseController(IMediator mediator)
    {
        this.Mediator = mediator;
    }

    protected UtilitiesServices ApplicationContext => HttpContext.ApplicationContext();

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
