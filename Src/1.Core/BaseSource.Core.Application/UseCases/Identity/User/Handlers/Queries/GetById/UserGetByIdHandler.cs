namespace BaseSource.Core.Application.UseCases.Identity.User.Handlers.Queries.GetById;

public class UserGetByIdHandler : QueryHandler<UserGetByIdQuery, UserGetByIdQueryModel>
{
    private readonly IUserQueryRepository _repository;
    public UserGetByIdHandler(ProviderFactory providerFactory, IUserQueryRepository repository) : base(providerFactory)
    {
        _repository = repository;
    }

    public override async Task<UserGetByIdQueryModel> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetAsync(request.Id);
            var result = Factory.Mapper.Map<UserEntity, UserGetByIdQueryModel>(entity);
            return result;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
