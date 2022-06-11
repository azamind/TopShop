using TopShopServer.Models;

namespace TopShopServer.Repositories.Product
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Models.Product>> GetProductsAsync();
        public Task<Models.Product?> GetProductAsync(int productId);
        public Task<Models.Product> Create(Models.Product product);
        public Task Update(int productId, Models.Product product);
    }
}
