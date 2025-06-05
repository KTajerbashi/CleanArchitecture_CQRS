using BaseSource.Core.Domain.Common.Exceptions;

namespace BaseSource.Core.Application.Common.Exceptions;

public class AppException : BaseException
{
    public AppException(string message) : base(message)
    {
    }

    public AppException(Exception exception) : base(exception)
    {
    }

    public AppException(string message, Exception exception) : base(message, exception)
    {
    }

    public AppException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}
