using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Model.DTOS;

namespace BlazorShop.Web.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllItems();
    }
}