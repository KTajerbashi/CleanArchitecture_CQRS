
namespace BaseSource.Core.Application.UseCases.PrintWorld.PrintedEvent;

public class PrintedEvent : DomainEvent
{
    public string Message { get; set; }

    public PrintedEvent(string message)
    {
        Message = message;
    }
}
public class PrintedEventHandler : DomainEventHandler<PrintedEvent>
{
    public PrintedEventHandler(ProviderFactory providerFactory) : base(providerFactory)
    {
    }

    public override async Task Handle(PrintedEvent notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        ILogger logger = ProviderFactory.LoggerFactory.CreateLogger<PrintedEventHandler>();
        logger.LogInformation("Printed Event: {Message}", notification.Message);
        // Here you can add additional logic to handle the printed event
    }
}