using Microsoft.EntityFrameworkCore;
using TopShopServer.Models;

namespace TopShopServer.Repositories.Size
{
    public class SizeRepository : ISizeRepository
    {
        private readonly TopShopContext _context;

        public SizeRepository(TopShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Size>> GetSizesAsync() => await _context.Sizes.ToListAsync();
    }
}
