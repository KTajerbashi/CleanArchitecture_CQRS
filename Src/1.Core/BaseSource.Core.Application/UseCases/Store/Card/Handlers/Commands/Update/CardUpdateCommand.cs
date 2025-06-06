using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;

namespace BaseSource.Core.Application.UseCases.Store.Card.Handlers.Commands.Update;

public record CardUpdateResponse();
public class CardUpdateCommand : Command<CardUpdateResponse>
{
}

public class CardUpdateValidator : AbstractValidator<CardUpdateCommand>
{
    public CardUpdateValidator()
    {

    }
}

public class CardUpdateHandler : CommandHandler<CardUpdateCommand, CardUpdateResponse>
{
    private readonly ICardCommandRepository _repository;
    public CardUpdateHandler(ProviderFactory factory, ICardCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<CardUpdateResponse> Handle(CardUpdateCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<CardUpdateCommand, CardUpdateCommand>().ReverseMap();
    }
}