using static BaseSource.Core.Domain.Aggregates.Identity.UserAggregate.Parameters.UserParameters;

namespace BaseSource.Core.Application.UseCases.Identity.User.Handler.Commands.Create;

public class UserCreateProfile : Profile
{
    public UserCreateProfile()
    {
        CreateMap<UserCreateCommand, UserParameter>().ReverseMap();
    }
}