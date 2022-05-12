namespace TopShopServer.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Brand? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public string? Title { get; set; }
        public IEnumerable<Size>? Size { get; set; }
        public decimal? Price { get; set; }
        public string? Article { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }    
        public string? Photo { get; set; }
        public DateTime? CreatedAt { get; set; }  
    }
}
