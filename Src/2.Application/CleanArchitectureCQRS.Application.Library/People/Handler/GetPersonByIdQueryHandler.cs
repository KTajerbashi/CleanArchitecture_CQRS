using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Application.Library.People.Queries;
using CleanArchitectureCQRS.Domain.Library.Person.Entities;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Handler
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQueryModel, Person>
    {
        private readonly IApplicationContext _context;
        public GetPersonByIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<Person> Handle(GetPersonByIdQueryModel request, CancellationToken cancellationToken)
        {
            var person = _context.People.Where(a => a.Id == request.Id).FirstOrDefault();
            if (person == null) return null;
            return person;
        }
    }
}
