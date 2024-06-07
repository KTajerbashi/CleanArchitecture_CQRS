using CleanArchitectureCQRS.Domain.Library.Person.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.Application.Library.Databases
{
    public interface IQueryApplicationContext
    {
        DbSet<Person> People { get; set; }

        Task<int> SaveChangesAsync();
    }
}
