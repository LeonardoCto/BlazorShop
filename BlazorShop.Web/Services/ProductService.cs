using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}