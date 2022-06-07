using Microsoft.EntityFrameworkCore;
using TopShopServer.Models;

namespace TopShopServer.Repositories.Brand
{
    public class BrandRepository : IBrandRepository
    {
        private readonly TopShopContext _context;

        public BrandRepository(TopShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Brand>> GetBrandsAsync() => await _context.Brands.ToListAsync();
    }
}
