using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Core.Application.UseCases.Store.Card.Handlers.Queries.GetAll;

public record CardGetAllResponse();
public class CardGetAllQuery : Query<List<CardGetAllResponse>>
{
}

public class CardGetAllValidator : AbstractValidator<CardGetAllQuery>
{
    public CardGetAllValidator()
    {

    }
}

public class CardGetAllHandler : QueryHandler<CardGetAllQuery, List<CardGetAllResponse>>
{
    private readonly ICardQueryRepository _repository;
    public CardGetAllHandler(ProviderFactory factory, ICardQueryRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<List<CardGetAllResponse>> Handle(CardGetAllQuery Query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<CardGetAllQuery, CardGetAllQuery>().ReverseMap();
    }
}
