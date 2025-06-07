using BaseSource.Core.Domain.Common.Exceptions;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.Exceptions;

public class CommandDbException : BaseException
{
    public CommandDbException(string message) : base(message)
    {
    }
}


public class CommandTransactionException : CommandDbException
{
    public CommandTransactionException(string message) : base(message)
    {
    }
}
