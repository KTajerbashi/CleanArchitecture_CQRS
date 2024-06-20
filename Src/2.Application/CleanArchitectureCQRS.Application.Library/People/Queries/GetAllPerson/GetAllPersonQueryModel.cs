using CleanArchitectureCQRS.Domain.Library.People.Entities;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Queries.GetAllPerson
{
    public record GetAllPersonQueryModel : IRequest<IEnumerable<Person>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
