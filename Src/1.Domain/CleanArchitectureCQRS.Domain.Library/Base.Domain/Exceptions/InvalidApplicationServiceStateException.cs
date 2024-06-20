namespace CleanArchitectureCQRS.Domain.Library.Base.Domain.Exceptions;

public class InvalidApplicationServiceStateException : DomainStateException
{
    public InvalidApplicationServiceStateException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}