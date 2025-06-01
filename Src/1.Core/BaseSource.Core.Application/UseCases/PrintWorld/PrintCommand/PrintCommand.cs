
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
public class PrintCommandValidator : AbstractValidator<PrintCommand>
{
    public PrintCommandValidator()
    {
        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("Message cannot be empty.")
            .MaximumLength(20).WithMessage("Message Maximum Length Must Be 20.")
            .Length(5,10).WithMessage("Message Length Must Between 5 and 10 Charecter.")
            ;
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

        return new PrintResponse($"Success Command With Message : {command.Message}");
    }
}