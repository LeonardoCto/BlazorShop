using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Model.DTOS;

namespace BlazorShop.Web.Services.Carts
{
    public interface ICartService
    {

        Task<List<CartItemDto>> GetUserItems(int userId);
        Task<CartItemDto> AddItem(CartItemAddDto cartItemAddDto);
        Task<CartItemDto> DeleteItem(int id);


        
    }
}