using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.ApplicationServices.Commands;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TData"></typeparam>
public interface ICommandHandler<TCommand, TData> : IRequestHandler<TCommand, TData>
    where TCommand : ICommand<TData>
{
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TCommand"></typeparam>
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
    Task<CommandResult> Handle(TCommand request);
}

