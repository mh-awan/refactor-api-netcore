using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RefactorThis.Models;
using RefactorThis.Repositories;
using RefactorThis.Services.Responses;

namespace RefactorThis.Services
{
    public class ProductOptionService : IProductOptionService
    {
        private readonly IProductOptionRepository _productOptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductOptionService(IProductOptionRepository productOptionRepository, IUnitOfWork unitOfWork)
        {
            _productOptionRepository = productOptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductOption>> GetProductOptionsAsync(Guid productId)
        {
            return await _productOptionRepository.ListAsync(productId);
        }

        public async Task<ProductOption> GetProductOptionByIdAsync(Guid productId, Guid id)
        {
            return await _productOptionRepository.FindByIdAsync(productId, id);
        }

        public async Task<ProductOptionResponse> SaveProductOptionAsync(Guid productId, ProductOption productOption)
        {
            try
            {
                productOption.ProductId = productId;
                await _productOptionRepository.AddAsync(productOption);
                await _unitOfWork.CompleteAsync();

                return new ProductOptionResponse(productOption);
            }
            catch (Exception ex)
            {
                return new ProductOptionResponse($"Error occurred while saving option: {ex.Message}");
            }
        }

        public async Task<ProductOptionResponse> UpdateProductOptionAsync(Guid productId, Guid id, ProductOption productOption)
        {
            var existingProductOption = await _productOptionRepository.FindByIdAsync(productId , id);

            if (existingProductOption == null)
                return new ProductOptionResponse("Option not found.");

            existingProductOption.Name = productOption.Name;
            existingProductOption.Description = productOption.Description;

            try
            {
                _productOptionRepository.Update(existingProductOption);
                await _unitOfWork.CompleteAsync();

                return new ProductOptionResponse(existingProductOption);
            }
            catch (Exception ex)
            {
                return new ProductOptionResponse($"Error occurred while updating option: {ex.Message}");
            }
        }

        public async Task<ProductOptionResponse> DeleteProductOptionAsync(Guid productId, Guid id)
        {
            var existingProductOption = await _productOptionRepository.FindByIdAsync(productId, id);

            if (existingProductOption == null)
                return new ProductOptionResponse("Option not found.");

            try
            {
                _productOptionRepository.Remove(existingProductOption);
                await _unitOfWork.CompleteAsync();

                return new ProductOptionResponse(existingProductOption);
            }
            catch (Exception ex)
            {
                return new ProductOptionResponse($"Error occurred while deleting option: {ex.Message}");
            }
        }
    }
}