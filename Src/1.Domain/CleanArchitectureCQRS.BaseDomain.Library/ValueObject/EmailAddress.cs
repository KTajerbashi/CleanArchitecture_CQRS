namespace CleanArchitectureCQRS.BaseDomain.Library.ValueObject;

public class EmailAddress
{
    public string Value { get; }

    public EmailAddress(string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress))
        {
            throw new ArgumentException("Email address cannot be empty.");
        }

        Value = emailAddress;
    }

    public static implicit operator string(EmailAddress emailAddress)
    {
        return emailAddress.Value;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        EmailAddress other = (EmailAddress)obj;
        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
