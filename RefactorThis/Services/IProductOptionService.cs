using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefactorThis.Models;
using RefactorThis.Services.Responses;

namespace RefactorThis.Services
{
    public interface IProductOptionService
    {
        Task<IEnumerable<ProductOption>> GetProductOptionsAsync(Guid productId);
        Task<ProductOption> GetProductOptionByIdAsync(Guid productId, Guid id);
        Task<ProductOptionResponse> SaveProductOptionAsync(Guid productId, ProductOption productOption);
        Task<ProductOptionResponse> UpdateProductOptionAsync(Guid productId, Guid id, ProductOption ProductOption);
        Task<ProductOptionResponse> DeleteProductOptionAsync(Guid productId, Guid id);
    }
}
