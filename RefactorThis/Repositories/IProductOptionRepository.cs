using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RefactorThis.Models;

namespace RefactorThis.Repositories
{
    public interface IProductOptionRepository
    {
        Task<IEnumerable<ProductOption>> ListAsync(Guid productId);
        Task AddAsync(ProductOption productOption);
        Task<ProductOption> FindByIdAsync(Guid productId, Guid id);
        void Update(ProductOption productOption);
        void Remove(ProductOption productOption);
    }
}
