//using CleanArchitectureCQRS.Domain.Library.People.DomainEvents;
//using CleanArchitectureCQRS.Domain.Library.People.ValueObjects;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace CleanArchitectureCQRS.Domain.Library.People.Entities
//{
//    [Table("People", Schema = "BUS"), Description("System Users")]
//    public class Person : AggregateRoot<int>
//    {


//        public Person()
//        {

//        }
//        public Person(
//            int id,
//            string firstName,
//            string lastName,
//            string email,
//            string mobileNumber,
//            string nationalCode,
//            string password
//            )
//        {
//            //if (id < 1)
//            //    throw new InvalidEntityStateException(MessagePatterns.IdInvalidationMessage);

//            //Id = id;
//            FirstName = firstName;
//            LastName = lastName;
//            Email = email;
//            MobileNumber = mobileNumber;
//            NationalCode = nationalCode;
//            Password = password;
//            AddEvent(new PersonCreated(
//                id,
//                BusinessId.Value,
//                firstName,
//                lastName,
//                email,
//                mobileNumber,
//                nationalCode,
//                password
//                )
//            );
//        }
//        public void ChangeFirstName(string firstName)
//        {
//            FirstName = firstName;
//            AddEvent(new PersonNameChanged(Id, firstName));
//        }
//        public void PersonSMSSend(string link)
//        {
//            AddEvent(new PersonSMSSend(Id, link));
//        }
//        public void PersonEmailSend()
//        {
//            AddEvent(new PersonEmailSend(Id));
//        }

//        #region Properties
//        public FirstName FirstName { get; set; }
//        public LastName LastName { get; set; }
//        public string NationalCode { get; set; }
//        public string MobileNumber { get; set; }
//        public string Email { get; set; }
//        public string Password { get; set; }
//        #endregion

//    }
//}
