namespace TopShopServer.Repositories.Size
{
    public interface ISizeRepository
    {
        public Task<IEnumerable<Models.Size>> GetSizesAsync();
    }
}
