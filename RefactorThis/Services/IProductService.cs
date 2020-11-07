using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RefactorThis.Models;
using RefactorThis.Services.Responses;

namespace RefactorThis.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<ProductResponse> SaveProductAsync(Product product);
        Task<ProductResponse> UpdateProductAsync(Guid id, Product product);
        Task<ProductResponse> DeleteProductAsync(Guid id);
    }
}
