//using CleanArchitectureCQRS.Domain.Library.Base.Domain.Entities;
//using CleanArchitectureCQRS.Domain.Library.Base.Domain.Exceptions;
//using CleanArchitectureCQRS.Domain.Library.People.DomainEvents;
//using CleanArchitectureCQRS.Domain.Library.People.ValueObjects;
//using CleanArchitectureCQRS.Domain.Library.Resources;
//using CleanArchitectureCQRS.Domain.Library.Base.Domain.ValueObjects;


//namespace CleanArchitectureCQRS.Domain.Library.People.Entities;

//public class PersonEventBase : AggregateRoot<int>
//{
//    #region Properties
//    public FirstName FirstName { get; set; }
//    public LastName LastName { get; set; }
//    #endregion
//    public PersonEventBase(
//        int id,
//        string firstName,
//        string lastName,
//        string nationalCode,
//        string mobileNumber,
//        string email,
//        string password
//        )
//    {
//        Apply(new PersonCreated(
//            id,
//            BusinessId.Value,
//            firstName, 
//            lastName,
//            email,
//            mobileNumber,
//            nationalCode,
//            password
//            ));

//    }
//    private void On(PersonCreated personCreated)
//    {
//        if (personCreated.Id < 1)
//        {
//            throw new InvalidEntityStateException(MessagePatterns.IdInvalidationMessage);
//        }
//        Id = personCreated.Id;
//        FirstName = personCreated.FirstName;
//        LastName = personCreated.LastName;
//        BusinessId = personCreated.BusinessId;
//    }
//}
