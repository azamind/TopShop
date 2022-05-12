using Microsoft.EntityFrameworkCore;

namespace TopShopServer.Models
{
    public class TopShopContext : DbContext
    {
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Size>? Sizes { get; set; }
        public string? DbPath { get; }

        public TopShopContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "topshop.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }
}
