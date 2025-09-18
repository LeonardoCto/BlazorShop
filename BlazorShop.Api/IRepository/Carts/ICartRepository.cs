using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Api.Entities;
using BlazorShop.Model.DTOS;

namespace BlazorShop.Api.IRepository.Carts
{
    public interface ICartRepository
    {
        public Task<IEnumerable<CartItem>> GetUserItems(int userId);
        public Task<CartItem> GetItem(int id);
        Task<CartItem> AddItem(CartItemAddDto cartItemAddDto);
        Task<CartItem> UpdateItem(CartItemUpdateDto cartItemUpdateDto);
        Task<CartItem> DeleteItem(int id);
    }
}