using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RefactorThis.Models;
using RefactorThis.Repositories;

namespace RefactorThis.Persistence.Repositories
{
    public class ProductOptionRepository : BaseRepository, IProductOptionRepository
    {
        public ProductOptionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductOption>> ListAsync(Guid productId)
        {
            return await (_context.ProductOptions.Where(p => p.ProductId == productId).ToListAsync());
        }

        public async Task<ProductOption> FindByIdAsync(Guid productId, Guid id)
        {
            return await _context.ProductOptions.Where(p => p.ProductId == productId).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(ProductOption productOption)
        {
            await _context.ProductOptions.AddAsync(productOption);
        }

        public void Update(ProductOption productOption)
        {
            _context.ProductOptions.Update(productOption);
        }

        public void Remove(ProductOption productOption)
        {
            _context.ProductOptions.Remove(productOption);
        }
    }
}
