using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorShop.Model.DTOS;

namespace BlazorShop.Web.Services
{
    public class ProductService : IProductService
    {
        public HttpClient _httpClient;
        public ILogger<ProductService> _logger;

        public ProductService(HttpClient httpClient, ILogger<ProductService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductDto>> GetAllItems()
        {
            try
            {
                var productsDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/products");
                return productsDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar Produtos");
                throw;
            }
        }

        public async Task<ProductDto> GetGetProductById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/products/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(ProductDto);
                    }
                    return await response.Content.ReadFromJsonAsync<ProductDto>();
                }

                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro ao obter produto pelo id={id} - {message}");
                    throw new Exception($"Status code : {response.StatusCode} - {message}");
                }
            }

            catch (Exception)
            {
                _logger.LogError($"Erro ao obter pelo id {id}");
                throw;
            }
        }
    }
}