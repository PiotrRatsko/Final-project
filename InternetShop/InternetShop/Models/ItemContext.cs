using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Models
{
    public class ItemContext
    {
        public List<IItem> Motos { get; set; } = new List<IItem>();
        public List<IItem> Sushis { get; set; } = new List<IItem>();
    }
}
