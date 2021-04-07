using System;
using System.ComponentModel.DataAnnotations;

namespace InternetShop.Domain.Entities
{
    public class Product
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Picter { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
