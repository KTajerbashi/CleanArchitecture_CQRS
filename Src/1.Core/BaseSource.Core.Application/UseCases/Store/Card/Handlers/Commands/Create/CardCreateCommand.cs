

using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;
using BaseSource.Core.Domain.Aggregates.Store.Card;

namespace BaseSource.Core.Application.UseCases.Store.Card.Handlers.Commands.Create;

public record CardCreateResponse(long Id);
public class CardCreateCommand : Command<CardCreateResponse>
{
    public string CardCode { get; set; }
}

public class CardCreateValidator : AbstractValidator<CardCreateCommand>
{
    public CardCreateValidator()
    {

    }
}

public class CardCreateHandler : CommandHandler<CardCreateCommand, CardCreateResponse>
{
    private readonly ICardCommandRepository _repository;
    public CardCreateHandler(ProviderFactory factory, ICardCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override async Task<CardCreateResponse> Handle(CardCreateCommand command, CancellationToken cancellationToken)
    {
        try
        {
            CardEntity entity = CardEntity.Create(command.CardCode);
            var id = await _repository.InsertAsync(entity);
            await _repository.SaveChangesAsync(cancellationToken);
            return new(id);
        }
        catch (Exception)
        {

            throw;
        }
    }
}

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<CardCreateCommand, CardCreateCommand>().ReverseMap();
    }
}
