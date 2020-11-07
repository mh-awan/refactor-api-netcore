using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RefactorThis.Models;
using RefactorThis.Repositories;

namespace RefactorThis.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.FindByIdAsync(id);
        }
    }
}
