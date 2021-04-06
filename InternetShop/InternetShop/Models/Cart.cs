using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Models
{
    public class Cart
    {
        public Dictionary<Product, int> CartItems { get; set; } = new Dictionary<Product, int>();
        public int TotalQuantity => CartItems.Count;
        public int TotalSum => CartItems.Select(x => (x.Key.Price * x.Value)).Sum();

        //void ggg()
        //{
        //    int kkk = CartItems.Select(x => (x.Key.Price * x.Value)).Sum();
        //}
        
    }
}
