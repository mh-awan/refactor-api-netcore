using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RefactorThis.Models;

namespace RefactorThis.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        //Task<ProductResponse> SaveAsync(Product product);
        //Task<ProductResponse> UpdateAsync(Guid id, Product product);
        //Task<ProductResponse> DeleteAsync(Guid id);
    }
}
