using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;

namespace BaseSource.Core.Application.UseCases.Store.Card.Handlers.Commands.UpdateProductCard;

public record UpdateProductCardResponse();
public class UpdateProductCardCommand : Command<UpdateProductCardResponse>
{
}

public class UpdateProductCardValidator : AbstractValidator<UpdateProductCardCommand>
{
    public UpdateProductCardValidator()
    {

    }
}

public class UpdateProductCardHandler : CommandHandler<UpdateProductCardCommand, UpdateProductCardResponse>
{
    private readonly ICardCommandRepository _repository;
    public UpdateProductCardHandler(ProviderFactory factory, ICardCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<UpdateProductCardResponse> Handle(UpdateProductCardCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<UpdateProductCardCommand, UpdateProductCardCommand>().ReverseMap();
    }
}
