using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;

namespace BaseSource.Core.Application.UseCases.Store.Card.Handlers.Queries.GetById;

public record CardGetByIdResponse(
    string CardCode
    );
public class CardGetByIdQuery : Query<CardGetByIdResponse>
{
    public Guid EntityId { get; set; }

    public CardGetByIdQuery(Guid entityId)
    {
        EntityId = entityId;
    }
}

public class CardGetByIdValidator : AbstractValidator<CardGetByIdQuery>
{
    public CardGetByIdValidator()
    {

    }
}

public class CardGetByIdHandler : QueryHandler<CardGetByIdQuery, CardGetByIdResponse>
{
    private readonly ICardQueryRepository _repository;
    private readonly ICardCommandRepository _cardCommandRepository;
    public CardGetByIdHandler(ProviderFactory factory, ICardQueryRepository repository, ICardCommandRepository cardCommandRepository) : base(factory)
    {
        _repository = repository;
        _cardCommandRepository = cardCommandRepository;
    }

    public override async Task<CardGetByIdResponse> Handle(CardGetByIdQuery Query, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetGraphAsync(Query.EntityId);
            var aggregate = await _cardCommandRepository.GetGraphAsync(Query.EntityId);
            return new CardGetByIdResponse(entity.CardCode);
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
        CreateMap<CardGetByIdQuery, CardGetByIdQuery>().ReverseMap();
    }
}
