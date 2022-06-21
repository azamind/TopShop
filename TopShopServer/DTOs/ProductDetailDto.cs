using TopShopServer.Models;

namespace TopShopServer.DTOs
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public Brand? Brand { get; set; }
        public Category? Category { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public string Article { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public IEnumerable<ProductSizeDto> ProductSizes { get; set; } = null!;
        public IEnumerable<string> PhotoLinks { get; set; } = null!;
    }
}
