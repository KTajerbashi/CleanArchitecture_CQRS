using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Domain.Library.Person.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.Application.Library.People.Queries.GetPersonById
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQueryModel, Person>
    {
        private readonly IQueryApplicationContext Context;

        public GetPersonByIdQueryHandler(IQueryApplicationContext context)
        {
            Context = context;
        }

        //public IQueryApplicationContext _Context { get; set; }

        public async Task<Person> Handle(GetPersonByIdQueryModel request, CancellationToken cancellationToken)
        {
            var person = await Context.People.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            if (person == null) return null;
            return person;
        }

       
    }
}
