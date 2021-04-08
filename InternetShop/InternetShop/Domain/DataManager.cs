using InternetShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Domain
{
    public class DataManager
    {
        public IStoreRepository StoreRepository { get; set; }


        public DataManager(IStoreRepository storeRepository)
        {
            StoreRepository = storeRepository;
        }
    }
}
