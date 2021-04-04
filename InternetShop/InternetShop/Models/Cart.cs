using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Models
{
    public class Cart
    {
        public Dictionary<Product, int> Items { get; set; }
    }
}
