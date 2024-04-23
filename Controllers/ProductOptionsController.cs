using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RefactorThis.Extensions;
using RefactorThis.Models;
using RefactorThis.Resources;
using RefactorThis.Services;

namespace RefactorThis.Controllers
{
    [Route("api/products/{productId}/options")]
    [ApiController]
    public class ProductOptionsController : ControllerBase
    {
        private readonly IProductOptionService _productOptionService;
        private readonly IMapper _mapper;

        public ProductOptionsController(IProductOptionService productOptionService, IMapper mapper)
        {
            _productOptionService = productOptionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductOptionResource>> GetProductOptionsAsync(Guid productId)
        {
            var productOptions = await _productOptionService.GetProductOptionsAsync(productId);
            var resources = _mapper.Map<IEnumerable<ProductOption>, IEnumerable<ProductOptionResource>>(productOptions);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<ProductOptionResource> GetProductOptionByIdAsync(Guid productId, Guid id)
        {
            var productOption = await _productOptionService.GetProductOptionByIdAsync(productId, id);
            var resource = _mapper.Map<ProductOption, ProductOptionResource>(productOption);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostProductOptionAsync(Guid productId, [FromBody] SaveProductOptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var productOption = _mapper.Map<SaveProductOptionResource, ProductOption>(resource);
            var result = await _productOptionService.SaveProductOptionAsync(productId, productOption);

            if (!result.Success)
                return BadRequest(ModelState.GetErrorMessages());

            var productOptionResource = _mapper.Map<ProductOption, ProductOptionResource>(result.ProductOption);

            return Ok(productOptionResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductOptionAsync(Guid productId, Guid id, [FromBody] SaveProductOptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var productOption = _mapper.Map<SaveProductOptionResource, ProductOption>(resource);
            var result = await _productOptionService.UpdateProductOptionAsync(productId, id, productOption);

            if (!result.Success)
                return BadRequest(result.Message);

            var productOptionResource = _mapper.Map<ProductOption, ProductOptionResource>(result.ProductOption);

            return Ok(productOptionResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductOptionAsync(Guid productId, Guid id)
        {
            var result = await _productOptionService.DeleteProductOptionAsync(productId, id);

            if (!result.Success)
                return BadRequest(result.Message);

            var productOptionResource = _mapper.Map<ProductOption, ProductOptionResource>(result.ProductOption);

            return Ok(productOptionResource);
        }
    }
}
