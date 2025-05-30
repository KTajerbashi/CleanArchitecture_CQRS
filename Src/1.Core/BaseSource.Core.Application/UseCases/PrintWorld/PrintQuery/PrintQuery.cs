namespace BaseSource.Core.Application.UseCases.PrintWorld.PrintQuery;

public class PrintResponse
{
    public string Message { get; set; }

    public PrintResponse(string message)
    {
        Message = message;
    }
}
public class PrintQuery : Query<PrintResponse>
{
    public string Message { get; set; }

    public PrintQuery(string message)
    {
        Message = message;
    }

}


public class PrintQueryHandler : QueryHandler<PrintQuery, PrintResponse>
{
    public PrintQueryHandler(ProviderFactory providerFactory) : base(providerFactory)
    {
    }

    public override async Task<PrintResponse> Handle(PrintQuery Query, CancellationToken cancellationToken)
    {
        Console.WriteLine("===================PrintQueryHandler===================");
        Console.WriteLine($"A : {DateTime.Now.ToString("G")} => {Query.Message}");
        await Task.Delay(2000);
        Console.WriteLine($"B : {DateTime.Now.ToString("G")} => {Query.Message}");
        Console.WriteLine("===================PrintQueryHandler===================");

        return new PrintResponse("Success Query");
    }
}