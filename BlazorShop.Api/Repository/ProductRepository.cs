using BlazorShop.Api.AppContext;
using BlazorShop.Api.Entities;
using BlazorShop.Api.IRepository;
using System.Collections.Concurrent;

namespace BlazorShop.Api.Repository
{
    public class ProductRepository : IProductRepository
    {

        //DI Com o contexto do EF Core essa classe acessa as info no db
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Product>> GetCartItems()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
