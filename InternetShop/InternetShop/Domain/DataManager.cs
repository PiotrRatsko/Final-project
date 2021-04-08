using InternetShop.Domain.Repositories;

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
