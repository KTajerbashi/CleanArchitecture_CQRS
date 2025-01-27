namespace BaseSource.Core.Application.Library.UseCases.Interfaces;

public interface IUser
{
    string GetUserAgent { get; }
    string GetUserIp { get; }
    string UserIdOrDefault { get; }
}
