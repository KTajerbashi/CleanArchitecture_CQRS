using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Application.Library.People.Queries;
using CleanArchitectureCQRS.Domain.Library.Person.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.Application.Library.People.Handler
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonQueryModel, IEnumerable<Person>>
    {
        private readonly IApplicationContext _context;
        public GetAllPersonsQueryHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> Handle(GetAllPersonQueryModel request, CancellationToken cancellationToken)
        {
            var personList= await _context.People.ToListAsync();
            if (personList == null)
            {
                return null;
            }
            return personList.AsReadOnly();
        }
    }
}
