using BlazorShop.Api.Entities;

namespace BlazorShop.Api.IRepository
{
    public interface IProductRepository
    {

        Task<IEnumerable<Product>> GetAllItems();
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>>GetProductByCategory(int id);
    }
}
