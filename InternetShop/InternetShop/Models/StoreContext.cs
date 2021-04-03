using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Models
{
    public class StoreContext
    {
        public List<Moto> Motos { get; set; } = new List<Moto>();
        public List<Sushi> Sushis { get; set; } = new List<Sushi>();

        public IProduct GetProductById(Guid guid)
        {
            var moto = Motos.Where(moto => moto.Id.Equals(guid)).FirstOrDefault();
            if (moto == null) return Sushis.Where(moto => moto.Id.Equals(guid)).FirstOrDefault();
            else
                return moto;
        }
    }
}
