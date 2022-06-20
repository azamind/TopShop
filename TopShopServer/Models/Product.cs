﻿using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TopShopServer.DTOs;

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
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
        [Required]
        public string? Article { get; set; }
        [Required]
        public string? Code { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? ShortDescription { get; set; }
        public string Photo { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        [NotMapped]
        public IEnumerable<int> Sizes { get; set; } = null!;
        [NotMapped]
        public IEnumerable<ProductSizeDto> ProductSizes { get; set; } = null!;
    }
}
