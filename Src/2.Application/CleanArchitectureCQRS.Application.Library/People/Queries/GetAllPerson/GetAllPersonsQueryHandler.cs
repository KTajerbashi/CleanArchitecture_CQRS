using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Domain.Library.Person.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.Application.Library.People.Queries.GetAllPerson
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonQueryModel, IEnumerable<Person>>
    {
        private readonly IQueryApplicationContext _context;
        public GetAllPersonsQueryHandler(IQueryApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> Handle(GetAllPersonQueryModel request, CancellationToken cancellationToken)
        {
            var personList = await _context.People.ToListAsync();
            if (personList == null)
            {
                return null;
            }
            return personList.AsReadOnly();
        }
    }
}
