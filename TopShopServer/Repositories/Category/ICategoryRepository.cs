namespace TopShopServer.Repositories.Category
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Models.Category>> GetCategoriesAsync();
    }
}
