using BlazorShop.Api.AppContext;
using BlazorShop.Api.Entities;
using BlazorShop.Api.IRepository;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products
                        .Include(c => c.Category)
                        .SingleOrDefaultAsync(c => c.Id == id);
            return product;
        }
        public async Task<IEnumerable<Product>> GetAllItems()
        {
            var productList = await _context.Products
                       .Include(c => c.Category)
                       .ToListAsync();
            return productList;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(int id)
        {
           var productCategory = await _context.Products
                       .Include(c => c.Category)
                       .Where(p => p.CategoryId == id).ToListAsync();
            return productCategory;
        }

    }
}
