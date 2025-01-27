namespace BaseSource.Core.Domain.Library.BaseDomain.Exceptions;

public class InvalidEntityStateException : DomainStateException
{
    public InvalidEntityStateException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}
