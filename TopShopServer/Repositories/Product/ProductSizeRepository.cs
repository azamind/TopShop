using Microsoft.EntityFrameworkCore;
using TopShopServer.Models;

namespace TopShopServer.Repositories.Product
{
    public class ProductSizeRepository : IProductSizeRepository
    {
        private readonly TopShopContext _context;

        public ProductSizeRepository(TopShopContext context)
        {
            _context = context;
        }

        public async Task Create(IEnumerable<int> ProductSizes, int ProductId)
        {
            List<ProductSize> sizes = new List<ProductSize>();
            
            foreach (var productSize in ProductSizes)
            {
                sizes.Add(new ProductSize { ProductId = ProductId, SizeId = productSize });
            }

            _context.ProductSizes.AddRange(sizes);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductSize>> GetSizesAsync(int ProductId)
        {
            return await _context.ProductSizes
                .Include(ps => ps.Size)
                .Where(ps => ps.ProductId == ProductId).ToListAsync();
        }
    }
}
