using TopShopServer.Models;

namespace TopShopServer.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public IEnumerable<string>? Photo { get; set; }
        public string? BrandName { get; set; } = string.Empty;
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
