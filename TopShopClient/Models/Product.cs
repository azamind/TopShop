namespace TopShopClient.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int? BrandId { get; set; } = null;
        public int? CategoryId { get; set; } = null;
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public string? Article { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
