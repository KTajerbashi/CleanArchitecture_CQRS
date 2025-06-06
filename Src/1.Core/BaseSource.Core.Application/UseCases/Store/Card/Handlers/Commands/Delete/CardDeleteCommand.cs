using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;

namespace BaseSource.Core.Application.UseCases.Store.Card.Handlers.Commands.Delete;

public record CardDeleteResponse();
public class CardDeleteCommand : Command<CardDeleteResponse>
{
    public Guid EntityId { get; set; }

    public CardDeleteCommand(Guid entityId)
    {
        EntityId = entityId;
    }
}

public class CardDeleteValidator : AbstractValidator<CardDeleteCommand>
{
    public CardDeleteValidator()
    {

    }
}

public class CardDeleteHandler : CommandHandler<CardDeleteCommand, CardDeleteResponse>
{
    private readonly ICardCommandRepository _repository;
    public CardDeleteHandler(ProviderFactory factory, ICardCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<CardDeleteResponse> Handle(CardDeleteCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<CardDeleteCommand, CardDeleteCommand>().ReverseMap();
    }
}