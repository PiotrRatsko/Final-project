using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Models
{
    public class Cart
    {
        public Dictionary<IProduct, int> Items { get; set; }
    }
}
