using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;

namespace BaseSource.Core.Application.UseCases.Store.Card.Handlers.Commands.DeleteProductCard;

public record DeleteProductCardResponse();
public class DeleteProductCardCommand : Command<DeleteProductCardResponse>
{
    public Guid EntityId { get; set; }

    public DeleteProductCardCommand(Guid entityId)
    {
        EntityId = entityId;
    }
}

public class DeleteProductCardValidator : AbstractValidator<DeleteProductCardCommand>
{
    public DeleteProductCardValidator()
    {

    }
}

public class DeleteProductCardHandler : CommandHandler<DeleteProductCardCommand, DeleteProductCardResponse>
{
    private readonly ICardCommandRepository _repository;
    public DeleteProductCardHandler(ProviderFactory factory, ICardCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<DeleteProductCardResponse> Handle(DeleteProductCardCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<DeleteProductCardCommand, DeleteProductCardCommand>().ReverseMap();
    }
}