using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;
using BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;
using BaseSource.Core.Domain.Aggregates.Store.Card;
using BaseSource.Core.Domain.Aggregates.Store.Product;

namespace BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.CreateProductWithDetails;

public class CreateProductWithDetailsHandler : CommandHandler<CreateProductWithDetailsCommand, CreateProductWithDetailsResponse>
{
    private readonly IProductCommandRepository _repository;
    private readonly ICardCommandRepository _cardCommandRepository;
    private readonly ILogger<CreateProductWithDetailsHandler> _logger;
    public CreateProductWithDetailsHandler(ProviderFactory factory, IProductCommandRepository repository, ICardCommandRepository cardCommandRepository) : base(factory)
    {
        _repository = repository;
        _cardCommandRepository = cardCommandRepository;
        _logger = factory.LoggerFactory.CreateLogger<CreateProductWithDetailsHandler>();
    }

    public override async Task<CreateProductWithDetailsResponse> Handle(CreateProductWithDetailsCommand command, CancellationToken cancellationToken)
    {
        //await _repository.BeginTransactionAsync(cancellationToken);
        try
        {

            CreateProductWithDetailsResponse response = new CreateProductWithDetailsResponse();

            var cardEntity = CardEntity.Create(command.CardCode);
            await _cardCommandRepository.InsertAsync(cardEntity);


            var productEntity = ProductEntity.Create(command.Title,command.Details);
            //await _repository.SaveChangesAsync(cancellationToken);
            cardEntity.AddProduct(productEntity.Id);

            await _repository.InsertAsync(productEntity);
            foreach (var card in command.ProductDetails)
            {
                productEntity.AddDetail(card.Title, card.Value);
            }

            await _repository.SaveChangesAsync(cancellationToken);
            return response;
        }
        catch (Exception ex)
        {
            //await _repository.RollbackTransactionAsync(cancellationToken);
            throw ex;
        }
    }
}
