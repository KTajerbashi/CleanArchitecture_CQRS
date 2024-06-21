using CleanArchitectureCQRS.Domain.Library.Catalogs.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.Application.Library.Databases
{
    public interface IApplicationContext
    {
        DbSet<CatalogItem> CatalogItems { get; set; }

        Task<int> SaveChangesAsync();
    }
}
