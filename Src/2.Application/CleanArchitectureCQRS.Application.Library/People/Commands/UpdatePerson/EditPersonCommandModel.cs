using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.UpdatePerson
{
    public class EditPersonCommandModel : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}
