namespace TopShopClient.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Article { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public IEnumerable<ProductSize> ProductSizes { get; set; }
        public IEnumerable<string> PhotoLinks { get; set; }

    }
}
