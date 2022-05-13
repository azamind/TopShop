using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace TopShopServer.Models
{
    public class TopShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Size> Sizes { get; set; } = null!;
        public DbSet<ProductSize> ProductSizes { get; set; } = null!;

        public TopShopContext(DbContextOptions<TopShopContext> options): base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasData(
                    new Brand
                    {
                        Id = 1,
                        Name = "Nike",
                        CreatedAt = DateTime.Now,
                    },
                    new Brand
                    {
                        Id = 2,
                        Name = "Adidas",
                        CreatedAt = DateTime.Now,
                    },
                    new Brand
                    {
                        Id = 3,
                        Name = "Puma",
                        CreatedAt = DateTime.Now,
                    },
                    new Brand
                    {
                        Id = 4,
                        Name = "Peacful Hooligan",
                        CreatedAt = DateTime.Now,
                    },
                    new Brand
                    {
                        Id = 5,
                        Name = "The North Face",
                        CreatedAt = DateTime.Now,
                    },
                    new Brand
                    {
                        Id = 6,
                        Name = "Alpha Industries",
                        CreatedAt = DateTime.Now,
                    },
                    new Brand
                    {
                        Id = 7,
                        Name = "Stone Island",
                        CreatedAt = DateTime.Now,
                    },
                    new Brand
                    {
                        Id = 8,
                        Name = "Polo Ralph Lauren",
                        CreatedAt = DateTime.Now,
                    },
                    new Brand
                    {
                        Id = 9,
                        Name = "Tommy Jeans",
                        CreatedAt = DateTime.Now,
                    },
                    new Brand
                    {
                        Id = 10,
                        Name = "thisisneverthat",
                        CreatedAt = DateTime.Now,
                    }
                );

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Sneakers",
                        ParentId = null,
                        CreatedAt = DateTime.Now,
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Hoodies",
                        ParentId = null,
                        CreatedAt = DateTime.Now,
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "T-shirt",
                        ParentId = null,
                        CreatedAt = DateTime.Now,
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Jackets",
                        ParentId = null,
                        CreatedAt = DateTime.Now,
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Jeans",
                        ParentId = null,
                        CreatedAt = DateTime.Now,
                    }
                );

            modelBuilder.Entity<Size>()
                .HasData(
                    new Size 
                    {
                        Id = 1,
                        Name = "S"
                    },
                    new Size
                    {
                        Id = 2,
                        Name = "M"
                    },
                    new Size
                    {
                        Id = 3,
                        Name = "L"
                    },
                    new Size
                    {
                        Id = 4,
                        Name = "XL"
                    },
                    new Size
                    {
                        Id = 5,
                        Name = "40"
                    },
                    new Size
                    {
                        Id = 6,
                        Name = "41"
                    },
                    new Size
                    {
                        Id = 7,
                        Name = "42"
                    }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 1,
                        BrandId = 1,
                        CategoryId = 1,
                        Title = "ACG Air Mada",
                        Price = (decimal?)124.55,
                        Article = "20943",
                        Code = "332-847",
                        Description = "Nike its a best brand in sneakers category",
                        Photo = "some.jpg",
                        CreatedAt = DateTime.Now
                    }
                );

            modelBuilder.Entity<ProductSize>()
                .HasData(
                    new ProductSize
                    {
                        Id = 1,
                        ProductId = 1,
                        SizeId = 5
                    },
                    new ProductSize
                    {
                        Id = 2,
                        ProductId = 1,
                        SizeId = 6
                    },
                    new ProductSize
                    {
                        Id = 3,
                        ProductId = 1,
                        SizeId = 7
                    }
                );
        }

    }
}
