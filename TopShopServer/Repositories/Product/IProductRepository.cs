using TopShopServer.Models;

namespace TopShopServer.Repositories.Product
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Models.Product>> GetProductsAsync();
    }
}
