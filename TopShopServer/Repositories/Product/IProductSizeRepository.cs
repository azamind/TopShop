namespace TopShopServer.Repositories.Product
{
    public interface IProductSizeRepository
    {
        public Task Create(IEnumerable<int> ProductSizes, int ProductId);
        public Task<IEnumerable<Models.ProductSize>> GetSizesAsync(int ProductId);
    }
}
