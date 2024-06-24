namespace CleanArchitectureCQRS.Domain.Library.Aggregates.Users.Resources
{
    public class MessagePatterns
    {
        public static string EmptyStringValidationMessage = "The value For {0} could not be null";
        public static string IdInvalidationMessage = "The Value for Id could not be less than 1";
        public static string StringLengthValidationMessage = "The length For {0} should be between {5} and {10}";
        public static string FirstName = nameof(FirstName);
        public static string LastName = nameof(LastName);
    }
}
