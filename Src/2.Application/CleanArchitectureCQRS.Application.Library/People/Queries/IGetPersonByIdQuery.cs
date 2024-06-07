using CleanArchitectureCQRS.Domain.Library.Person.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Application.Library.People.Queries
{
    public class GetAllPersonQueryModel : IRequest<List<Person>>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
    public class GetPersonByIdQueryModel : IRequest<Person>
    {
        public Guid Id { get; set; }
    }
}
