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

        public async Task Create(Models.Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Models.Product?> GetProductAsync(int productId)
        {
            return await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Models.Product>> GetProductsAsync() => await _context.Products.ToListAsync();

        public async Task Update(int productId, Models.Product product)
        {
            var entity = await GetProductAsync(productId);

            if (entity == null)
            {
                throw new Exception("Product not found.");
            }

            entity.Title = product.Title;
            entity.Price = product.Price;
            entity.Article = product.Article;
            entity.Code = product.Code;
            entity.Description = product.Description;
            entity.ShortDescription = product.ShortDescription;
            entity.Photo = product.Photo;
            await _context.SaveChangesAsync();
        }
    }
}
