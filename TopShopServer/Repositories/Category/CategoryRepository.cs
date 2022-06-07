using Microsoft.EntityFrameworkCore;
using TopShopServer.Models;

namespace TopShopServer.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TopShopContext _context;

        public CategoryRepository(TopShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Category>> GetCategoriesAsync() => await _context.Categories.ToListAsync();
    }
}
