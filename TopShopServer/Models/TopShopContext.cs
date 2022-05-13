using Microsoft.EntityFrameworkCore;

namespace TopShopServer.Models
{
    public class TopShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Size> Sizes { get; set; } = null!;

        public TopShopContext(DbContextOptions<TopShopContext> options): base(options)
        {
        }

    }
}
