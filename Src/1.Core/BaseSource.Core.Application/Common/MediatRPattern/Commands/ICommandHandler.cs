
using BaseSource.Core.Application.Providers;

namespace BaseSource.Core.Application.Common.MediatRPattern.Commands;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : Command
{ }
public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
    where TCommand : Command
{
    protected readonly ProviderFactory ProviderFactory;
    protected CommandHandler(ProviderFactory providerFactory)
    {
        ProviderFactory = providerFactory;
    }

    public abstract Task Handle(TCommand command, CancellationToken cancellationToken);
}


public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : Command<TResponse>
{ }
public abstract class CommandHandler<TCommand, TResponse> : ICommandHandler<TCommand, TResponse>
    where TCommand : Command<TResponse>
{
    protected readonly ProviderFactory Factory;
    protected CommandHandler(ProviderFactory factory)
    {
        Factory = factory;
    }
    public abstract Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
}
