namespace TopShopServer.Repositories.Brand
{
    public interface IBrandRepository
    {
        public Task<IEnumerable<Models.Brand>> GetBrandsAsync();
    }
}
