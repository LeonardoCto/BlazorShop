using BlazorShop.Api.Entities;

namespace BlazorShop.Api.IRepository
{
    public interface IProductRepository
    {

        Task<IEnumerable<Product>> GetCartItems();
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>>GetProductByCategory(int id);
    }
}
