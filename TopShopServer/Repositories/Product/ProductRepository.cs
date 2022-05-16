using Microsoft.EntityFrameworkCore;
using TopShopServer.Models;

namespace TopShopServer.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly TopShopContext _context;

        public ProductRepository(TopShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
