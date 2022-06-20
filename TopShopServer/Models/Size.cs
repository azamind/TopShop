using System.ComponentModel.DataAnnotations;

namespace TopShopServer.Models
{
    public class Size
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
