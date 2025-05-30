namespace BaseSource.Core.Application.UseCases.PrintWorld.PrintCommand;

public class PrintResponse
{
    public string Message { get; set; }

    public PrintResponse(string message)
    {
        Message = message;
    }
}
public class PrintCommand : Command<PrintResponse>
{
    public string Message { get; set; }

    public PrintCommand(string message)
    {
        Message = message;
    }

}


public class PrintCommandHandler : CommandHandler<PrintCommand, PrintResponse>
{
    public PrintCommandHandler(ProviderFactory providerFactory) : base(providerFactory)
    {
    }

    public override async Task<PrintResponse> Handle(PrintCommand command, CancellationToken cancellationToken)
    {
        Console.WriteLine("===================PrintCommandHandler===================");
        Console.WriteLine($"A : {DateTime.Now.ToString("G")} => {command.Message}");
        await Task.Delay(2000);
        Console.WriteLine($"B : {DateTime.Now.ToString("G")} => {command.Message}");
        Console.WriteLine("===================PrintCommandHandler===================");

        return new PrintResponse("Success Command");
    }
}