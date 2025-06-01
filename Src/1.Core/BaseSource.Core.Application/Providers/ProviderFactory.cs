using BaseSource.Utilities.CacheProvider;
using BaseSource.Utilities.DapperProvider;
using BaseSource.Utilities.MapperProvider;
using BaseSource.Utilities.SerializerProvider;
using Microsoft.Extensions.Logging;

namespace BaseSource.Core.Application.Providers;

public class ProviderFactory
{
    public readonly IMediator Mediator;
    public readonly IPublisher Publisher;
    public readonly INotificationPublisher NotificationPublisher;
    public readonly ILoggerFactory LoggerFactory;
    public readonly IQueryExecute Query;
    public readonly ICacheAdapter Cache;
    public readonly IJsonSerializer Json;
    public readonly IMapperAdapter Mapper;

    public ProviderFactory(
        IMediator mediator,
        IPublisher publisher,
        INotificationPublisher notificationPublisher,
        ILoggerFactory loggerFactory
        )
    {
        Mediator = mediator;
        Publisher = publisher;
        NotificationPublisher = notificationPublisher;
        LoggerFactory = loggerFactory;
    }

    //public ProviderFactory(
    //    IMediator mediator,
    //    IPublisher publisher,
    //    INotificationPublisher notificationPublisher,
    //    IQueryExecute queryExecute,
    //    ICacheAdapter cacheAdapter,
    //    IJsonSerializer jsonSerializer,
    //    IMapperAdapter mapper,
    //    ILoggerFactory loggerFactory)
    //{
    //    Mediator = mediator;
    //    Publisher = publisher;
    //    NotificationPublisher = notificationPublisher;
    //    Query = queryExecute;
    //    Cache = cacheAdapter;
    //    Json = jsonSerializer;
    //    Mapper = mapper;
    //    LoggerFactory = loggerFactory;
    //}
}
