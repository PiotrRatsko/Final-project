using System.Collections.Generic;

namespace InternetShop.Models
{
    public class ItemContext
    {
        public List<Moto> Motos { get; set; } = new List<Moto>();
        public List<Sushi> Sushis { get; set; } = new List<Sushi>();
    }
}
