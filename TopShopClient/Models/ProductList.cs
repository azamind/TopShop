namespace TopShopClient.Models
{
    public class ProductList
    {
        public int Id { get; set; }
        public string Photo { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
