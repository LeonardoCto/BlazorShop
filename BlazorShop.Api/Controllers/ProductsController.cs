using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Api.IRepository;
using BlazorShop.Api.Mappings;
using BlazorShop.Model.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllItems()
        {
            try
            {
                var products = await _productRepository.GetAllItems();
                if (products is null)
                {
                    return NotFound();
                }
                else
                {
                    var productsDtos = products.ConvertProductsToDto();
                    return Ok(productsDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);
                if (product is null)
                {
                    return NotFound("Product not found");
                }
                else
                {
                    var productDto = product.ConvertProductToDto();
                    return Ok(productDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetProductByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductByCategory(int categoryId)
        {
            try
            {
                var products = await _productRepository.GetProductByCategory(categoryId);
                var productDtos = products.ConvertProductsToDto();
                return Ok(productDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}