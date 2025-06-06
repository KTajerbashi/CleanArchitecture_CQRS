using static BaseSource.Core.Domain.Aggregates.Identity.UserAggregate.Parameters.UserParameters;

namespace BaseSource.Core.Application.UseCases.Identity.User.Handlers.Commands.Create;

public class UserCreateHandler : CommandHandler<UserCreateCommand, UserCreateResponse>
{
    private readonly IUserCommandRepository _repository;
    public UserCreateHandler(ProviderFactory providerFactory, IUserCommandRepository repository) : base(providerFactory)
    {
        _repository = repository;
    }

    public override async Task<UserCreateResponse> Handle(UserCreateCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var paramter = Factory.Mapper.Map<UserCreateCommand,UserParameter>(command);
            var userEntity = new UserEntity(paramter);
            var id = await _repository.InsertAsync(userEntity);
            if (id == null)
            {
                throw new AppException("User creation failed.");
            }
            return new UserCreateResponse("User Created Success.", true);
        }
        catch (AppException ex)
        {

            throw;
        }
        catch (ApplicationException ex)
        {

            throw;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
