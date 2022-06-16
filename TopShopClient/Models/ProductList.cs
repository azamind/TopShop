namespace TopShopClient.Models
{
    public class ProductList
    {
        public int Id { get; set; }
        public IEnumerable<string> Photo { get; set; } = new List<string>();
        public string BrandName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
