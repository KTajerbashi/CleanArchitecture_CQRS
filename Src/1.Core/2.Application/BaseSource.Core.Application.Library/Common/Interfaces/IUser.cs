namespace BaseSource.Core.Application.Library.Common.Interfaces;

public interface IUser
{
    string GetUserAgent { get; }
    string GetUserIp { get; }
    string UserIdOrDefault { get; }
}
