using BaseSource.Core.Domain.Common.Exceptions;

namespace BaseSource.Core.Domain.Exceptions;

public class DomainLogicException : BaseException
{
    public DomainLogicException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}
public class DomainValueObjectException : BaseException
{
    public DomainValueObjectException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}
