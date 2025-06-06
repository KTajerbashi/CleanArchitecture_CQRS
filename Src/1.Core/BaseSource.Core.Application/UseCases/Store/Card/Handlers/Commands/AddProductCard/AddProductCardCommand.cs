using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;
using BaseSource.Core.Domain.Aggregates.Store.Card;

namespace BaseSource.Core.Application.UseCases.Store.Card.Handlers.Commands.AddProductCard;



public record AddProductCardResponse(long Id);
public class AddProductCardCommand : Command<AddProductCardResponse>
{
    public long CardId { get; set; }
    public long ProductId { get; set; }
}

public class AddProductCardValidator : AbstractValidator<AddProductCardCommand>
{
    public AddProductCardValidator()
    {

    }
}

public class AddProductCardHandler : CommandHandler<AddProductCardCommand, AddProductCardResponse>
{
    private readonly ICardCommandRepository _repository;
    public AddProductCardHandler(ProviderFactory factory, ICardCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override async Task<AddProductCardResponse> Handle(AddProductCardCommand command, CancellationToken cancellationToken)
    {
        try
        {
            CardEntity entity = await _repository.GetAsync(command.CardId);
            entity.AddProduct(command.ProductId);
            await _repository.SaveChangeAsync(cancellationToken);
            return new(entity.Id);
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
        CreateMap<AddProductCardCommand, AddProductCardCommand>().ReverseMap();
    }
}
