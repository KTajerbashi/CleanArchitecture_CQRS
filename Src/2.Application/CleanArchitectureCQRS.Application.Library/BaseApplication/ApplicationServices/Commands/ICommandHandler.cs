using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Commands;

/// <summary>
/// تمامی کامند ها باید ازین ارث بری کنند
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TData"></typeparam>
public interface ICommandHandler<TCommand, TData> : IRequestHandler<TCommand, CommandResult<TData>>
    where TCommand : ICommand<TData>
{
}

/// <summary>
/// تمامی کامند ها باید ازین ارث بری کنند
/// </summary>
/// <typeparam name="TCommand"></typeparam>
public interface ICommandHandler<TCommand>
    : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}

