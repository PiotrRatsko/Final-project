using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Models
{
    public class Cart
    {
        public Dictionary<Product, int> CartItems { get; set; } = new Dictionary<Product, int>();
        public int TotalQuantity => CartItems.Count;
        public int TotalSum => CartItems.Select(x => (x.Key.Price * x.Value)).Sum();
    }
}
