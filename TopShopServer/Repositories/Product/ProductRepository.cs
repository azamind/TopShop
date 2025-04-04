﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Models.Product> Create(Models.Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Models.Product?> GetProductAsync(int productId)
        {
            return await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Models.Product>> GetProductsAsync(int? CategoryId)
        {
            var query = _context.Products.Include(p => p.Brand);
            if (CategoryId == null)
            {
                return await query.ToListAsync();
            }
            return await query.Where(p => p.CategoryId == CategoryId).ToListAsync();
        }

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
