﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Image { get; set; }
        [Display(Name="Product Color")]
        public string ProductColor { get; set; }
        [Required]
        [Display(Name="Available")]
        public bool IsAvailable { get; set; } 
        [Display(Name="Product Type")]
        [Required]
        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public virtual ProductTypes? ProductTypes { get; set; }
        [Display(Name = "Special Tag")]
        [Required]
        public int SpecialTagId { get; set; }
        [ForeignKey("SpecialTagId")]
        public virtual SpecialTags? SpecialTags { get; set; }

    }
}
