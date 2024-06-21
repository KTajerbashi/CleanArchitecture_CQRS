using CleanArchitectureCQRS.Application.Library.Catalogs.Commands.Repository;
using CleanArchitectureCQRS.ContextDatabase.Library.Databases.Contexts;
using CleanArchitectureCQRS.Domain.Library.Catalogs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.ContextDatabase.Library.Catalogs
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly ApplicationContext _context;

        public CatalogItemRepository(ApplicationContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task AddAsync(CatalogItem catalogItem)
        {
            await _context.AddAsync(catalogItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CatalogItem catalogItem)
        {
            _context.Entry(catalogItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
