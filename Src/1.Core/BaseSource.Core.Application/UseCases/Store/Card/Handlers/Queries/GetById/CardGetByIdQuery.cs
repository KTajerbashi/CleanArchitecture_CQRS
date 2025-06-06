using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;

namespace BaseSource.Core.Application.UseCases.Store.Card.Handlers.Queries.GetById;

public record CardGetByIdResponse();
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
    public CardGetByIdHandler(ProviderFactory factory, ICardQueryRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<CardGetByIdResponse> Handle(CardGetByIdQuery Query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<CardGetByIdQuery, CardGetByIdQuery>().ReverseMap();
    }
}
