using System.ComponentModel.DataAnnotations;

namespace TopShopServer.Models
{
    public class ProductSize
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int SizeId { get; set; }
        public Size Size { get; set; } = null!;
    }
}
