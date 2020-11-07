using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RefactorThis.Models;
using RefactorThis.Repositories;
using RefactorThis.Services.Responses;

namespace RefactorThis.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.FindByIdAsync(id);
        }

        public async Task<ProductResponse> SaveProductAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Error occurred while saving product: {ex.Message}");
            }
        }

        public async Task<ProductResponse> UpdateProductAsync(Guid id, Product product)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new ProductResponse("Product not found.");

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.DeliveryPrice = product.DeliveryPrice;

            try
            {
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Error occurred while updating product: {ex.Message}");
            }
        }

        public async Task<ProductResponse> DeleteProductAsync(Guid id)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new ProductResponse("Product not found.");

            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Error occurred while deleting product: {ex.Message}");
            }
        }
    }
}
