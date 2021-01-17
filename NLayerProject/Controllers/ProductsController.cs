using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Entities;
using NLayerProject.Core.Services;
using NLayerProject.Dto;
using NLayerProject.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoriesById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto product)
        {
            var entity = await _productService.AddAsync(_mapper.Map<Product>(product));

            return Created(String.Empty, _mapper.Map<ProductDto>(entity));
        }

        [HttpPut]
        public IActionResult Update(ProductDto product)
        {
            var updatedProduct = _productService.Update(_mapper.Map<Product>(product));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedProduct = _productService.GetByIdAsync(id).Result;
            _productService.Remove(deletedProduct);

            return NoContent();
        }
        
    }
}
