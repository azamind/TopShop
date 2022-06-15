using TopShopServer.Models;

namespace TopShopServer.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Photo { get; set; }
        public Brand? Brand { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
