namespace TopShopClient.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int? BrandId { get; set; } = null;
        public int? CategoryId { get; set; } = null;
        public string Title { get; set; } = String.Empty;
        public decimal? Price { get; set; }
        public string Article { get; set; } = String.Empty;
        public string Code { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string ShortDescription { get; set; } = String.Empty;
        public string Photo { get; set; } = String.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public IEnumerable<int> Sizes { get; set; } = null!;
        public IEnumerable<ProductSize> ProductSizes { get; set; } = null!;
    }
}
