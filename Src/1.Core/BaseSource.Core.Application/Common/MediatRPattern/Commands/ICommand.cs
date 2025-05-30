
namespace BaseSource.Core.Application.Common.MediatRPattern.Commands;

public interface ICommand : IRequest { }
public interface ICommand<TResponse> : IRequest<TResponse> { }

public abstract class Command : ICommand { }
public abstract class Command<TResponse> : ICommand<TResponse> { }
