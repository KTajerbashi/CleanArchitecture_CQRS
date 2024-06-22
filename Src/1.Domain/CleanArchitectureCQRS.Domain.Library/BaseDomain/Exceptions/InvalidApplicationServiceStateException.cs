namespace CleanArchitectureCQRS.Domain.Library.BaseDomain.Exceptions;

public class InvalidApplicationServiceStateException : DomainStateException
{
    public InvalidApplicationServiceStateException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}