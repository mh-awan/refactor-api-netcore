using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RefactorThis.Models;

namespace RefactorThis.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task AddAsync(Product product);
        Task<Product> FindByIdAsync(Guid id);
        void Update(Product product);
        void Remove(Product product);
    }
}
