using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Domain.Entities
{
    public class CartModel
    {
        public Dictionary<ProductModel, int> CartItems { get; set; } = new Dictionary<ProductModel, int>();
        public int TotalQuantity => CartItems.Count;
        public int TotalSum => CartItems.Select(x => x.Key.Price * x.Value).Sum();
    }
}
