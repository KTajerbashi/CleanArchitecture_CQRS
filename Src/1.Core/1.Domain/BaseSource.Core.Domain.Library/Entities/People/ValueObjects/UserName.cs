using BaseSource.Core.Domain.Library.Common.ValueObjects;
using BaseSource.Core.Domain.Library.Entities.People.Resources;

namespace BaseSource.Core.Domain.Library.Entities.People.ValueObjects
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
