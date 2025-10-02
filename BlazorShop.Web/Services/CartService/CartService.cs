using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorShop.Model.DTOS;

namespace BlazorShop.Web.Services.Carts
{
    public class CartService : ICartService
    {

         public HttpClient _httpClient;
        public ILogger<CartService> _logger;

        public CartService(HttpClient httpClient, ILogger<CartService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<CartItemDto> AddItem(CartItemAddDto cartItemAddDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<CartItemAddDto>("api/Cart", cartItemAddDto);

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return default(CartItemDto);
            }

            return await response.Content.ReadFromJsonAsync<CartItemDto>();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"{response.StatusCode} Message = {message}");
        }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CartItemDto> DeleteItem(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Cart/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }
                return default(CartItemDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CartItemDto>> GetUserItems(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Cart/{userId}/GetUserItems");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<CartItemDto>().ToList();
            }

            return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http Status Code: {response.StatusCode} Message: {message}");
        }
            }
        catch (Exception)
            {
                throw;
            }
        }
    }
}