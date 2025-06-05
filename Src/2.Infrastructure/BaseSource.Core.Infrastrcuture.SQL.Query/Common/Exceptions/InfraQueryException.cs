using BaseSource.Core.Domain.Common.Exceptions;

namespace BaseSource.Core.Infrastrcuture.SQL.Query.Common.Exceptions;

public class InfraQueryException : BaseException
{
    public InfraQueryException(string message) : base(message)
    {
    }

    public InfraQueryException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}
