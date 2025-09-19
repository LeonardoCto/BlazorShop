using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Api.IRepository;
using BlazorShop.Api.IRepository.Carts;
using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repository;
using BlazorShop.Api.Repository.Carts;
using BlazorShop.Model.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorShop.Api.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller

    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CartController> _logger;

        public CartController(ILogger<CartController> logger, ICartRepository cartRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("{userId}/GetUserItems")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetUserItems(int userId)
        {

            try
            {
                var cartItems = await _cartRepository.GetUserItems(userId);

                if (cartItems == null)
                {
                    return NoContent();
                }

                var products = await _productRepository.GetAllItems();
                if (products == null)
                {
                    throw new Exception("Do not exists products...");
                }

                var cartItemsDto = cartItems.ConvertCartItemsToDto(products);
                return Ok(cartItemsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("## Error");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartItemDto>> GetItem(int id)
        {
            try
            {
                var cartItem = await _cartRepository.GetItem(id);
                if (cartItem == null)
                {
                    return NotFound($"Item not found");
                }

                var product = await _productRepository.GetProductById(cartItem.ProductId);
                if (product == null)
                {
                    return NotFound($"Item do not exist in DB");
                }

                var cartItemDto = cartItem.ConvertCartItemToDto(product);
                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"## ErroR to get item ={id}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<CartItemDto>> AddItem([FromBody] CartItemAddDto cartItemAddDto)
        {
            try
            {
                var newCartItem = await _cartRepository.AddItem(cartItemAddDto);

                if (newCartItem == null)
                {
                    return NoContent(); 
                }

                var product = await _productRepository.GetProductById(newCartItem.ProductId);

                if (product == null)
                {
                    throw new Exception($"Produto não localizado (Id: {cartItemAddDto.ProductId})");
                }

                var newCartItemDto = newCartItem.ConvertCartItemToDto(product);

                return CreatedAtAction(nameof(GetItem), new { id = newCartItem.Id }, newCartItemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("## Erro criar um novo item no carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}