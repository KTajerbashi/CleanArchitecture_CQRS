using BaseSource.Core.Application.UseCases.Store.Card.Repositories.Card;
using BaseSource.Core.Application.UseCases.Store.Product.Repositories.Product;
using BaseSource.Core.Domain.Aggregates.Store.Card;
using BaseSource.Core.Domain.Aggregates.Store.Product;

namespace BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.CreateProductWithDetails;

public class CreateProductWithDetailsHandler : CommandHandler<CreateProductWithDetailsCommand, CreateProductWithDetailsResponse>
{
    private readonly IProductCommandRepository _productRepository;
    private readonly ICardCommandRepository _cardRepository;
    private readonly ILogger<CreateProductWithDetailsHandler> _logger;

    public CreateProductWithDetailsHandler(
        ProviderFactory factory,
        IProductCommandRepository productRepository,
        ICardCommandRepository cardRepository)
        : base(factory)
    {
        _productRepository = productRepository;
        _cardRepository = cardRepository;
        _logger = factory.LoggerFactory.CreateLogger<CreateProductWithDetailsHandler>();
    }

    public override async Task<CreateProductWithDetailsResponse> Handle(
        CreateProductWithDetailsCommand command,
        CancellationToken cancellationToken)
    {
        const string handlerName = nameof(CreateProductWithDetailsHandler);

        try
        {
            _logger.LogInformation("{Handler} started at {DateTime}", handlerName, DateTime.Now);

            var result = await _productRepository.TransactionAsync(async () =>
            {
                // Create and add card
                var cardEntity = CardEntity.Create(command.CardCode);
                await _cardRepository.InsertAsync(cardEntity, cancellationToken);
                _logger.LogInformation("Card created with code: {CardCode}", command.CardCode);

                // Create product
                var productEntity = ProductEntity.Create(command.Title, command.Details);
                await _productRepository.InsertAsync(productEntity, cancellationToken);
                await _productRepository.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("Product created with title: {ProductTitle}", command.Title);

                // Add product to card
                cardEntity.AddProduct(productEntity.Id);
                await _cardRepository.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("Product associated with card");

                // Add product details
                foreach (var detail in command.ProductDetails)
                {
                    productEntity.AddDetail(detail.Title, detail.Value);
                    _logger.LogDebug("Added product detail: {DetailTitle}", detail.Title);
                }

                await _productRepository.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("All product details added successfully");

                return new CreateProductWithDetailsResponse();
            }, cancellationToken);

            _logger.LogInformation("{Handler} completed successfully at {DateTime}", handlerName, DateTime.Now);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Handler} failed at {DateTime}", handlerName, DateTime.Now);
            throw; // Re-throw the original exception to preserve stack trace
        }
    }
}