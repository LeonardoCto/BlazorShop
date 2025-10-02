using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Api.AppContext;
using BlazorShop.Api.Entities;
using BlazorShop.Api.IRepository.Carts;
using BlazorShop.Model.DTOS;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Repository.Carts
{
    public class CartRepository : ICartRepository
    {

        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CartItem> AddItem(CartItemAddDto cartItemAddDto)
        {
            if (await AlreadyExist(cartItemAddDto.CartId, cartItemAddDto.ProductId) == false)
            {
                var item = await (from product in _context.Products
                                  where product.Id == cartItemAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartId = cartItemAddDto.CartId,
                                      ProductId = product.Id,
                                      Quantity = cartItemAddDto.Quantity
                                  }).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await _context.CartItems.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }

        public async Task<CartItem> DeleteItem(int id)
        {
            var item = await _context.CartItems.FindAsync(id);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
                return item;
        }

        public async Task<CartItem?> GetItem(int id)
        {
            return await (from cart in _context.Carts
                          join cartItem in _context.CartItems
                          on cart.Id equals cartItem.CartId
                          where cartItem.Id == id
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Quantity = cartItem.Quantity,
                              CartId = cartItem.CartId
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetUserItems(int userId)
        {
            return await (from cart in _context.Carts
                          join cartItem in _context.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Quantity = cartItem.Quantity,
                              CartId = cartItem.CartId
                          }).ToListAsync();
        }

        public Task<CartItem> UpdateItem(CartItemUpdateDto cartItemUpdateDto)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> AlreadyExist(int cartId, int productId)
        {
            return await _context.CartItems.AnyAsync(c => c.CartId == cartId && c.ProductId == productId);
        }
    }
}