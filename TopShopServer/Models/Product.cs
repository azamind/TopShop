using System.ComponentModel.DataAnnotations;

namespace TopShopServer.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Brand? BrandId { get; set; }
        public Brand? Brand { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }
        [Required]
        public IEnumerable<Size>? Size { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public string? Article { get; set; }
        [Required]
        public string? Code { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Photo { get; set; }
        public DateTime? CreatedAt { get; set; }  
    }
}
