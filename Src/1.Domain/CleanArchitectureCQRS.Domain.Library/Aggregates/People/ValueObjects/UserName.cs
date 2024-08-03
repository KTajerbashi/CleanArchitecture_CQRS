
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.Resources;
using CleanArchitectureCQRS.Domain.Library.BaseDomain.Exceptions;
using CleanArchitectureCQRS.Domain.Library.BaseDomain.ValueObjects;

namespace CleanArchitectureCQRS.Domain.Library.Aggregates.People.ValueObjects
{
    public class UserName : BaseValueObject<UserName>
    {
        public static UserName FromString(string value) => new(value);
        //public static UserName FromGuid(Guid value) => new() { Value = value };

        public string Value { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public UserName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidValueObjectStateException(MessagePatterns.EmptyStringValidationMessage, nameof(UserName));
            }
            if (!(value.Length >= 5) && !(value.Length <= 10))
            {
                throw new InvalidValueObjectStateException(MessagePatterns.StringLengthValidationMessage, nameof(UserName), "5", "10");
            }
            Value = value;
        }
        public static explicit operator string(UserName userName) => userName.Value.ToString();
        public static implicit operator UserName(string value) => new(value);
    }
}
