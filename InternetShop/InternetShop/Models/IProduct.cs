using System;

namespace InternetShop.Models
{
    public interface IProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public string Picter { get; set; }
    }
}
