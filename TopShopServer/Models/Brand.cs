using System.ComponentModel.DataAnnotations;

namespace TopShopServer.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
