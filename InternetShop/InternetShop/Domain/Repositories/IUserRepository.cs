using InternetShop.Domain.Entities;

namespace InternetShop.Domain.Repositories
{
    public interface IUserRepository
    {
        public User GetUserByEmail(string email);
        public User GetUserByEmailAndPassword(string email, string password);
        public void AddUser(User user);
        public void AddToCart(Product product, string email);
        public void PlusQuantity(Product product, string email);
        public void MinusQuantity(Product product, string email);
        public void RemoveProductFromCard(Product product, string email);
    }
}
