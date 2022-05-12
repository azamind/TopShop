using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopShopServer.Models
{
    public class Product
    {
        public int Id { get; set; }
        [ForeignKey("BrandId")]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }
        [Required]
        public ICollection<Size>? Sizes { get; set; }
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
