namespace InternetShop.Domain.Entities
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Cart Cart { get; set; } = new Cart();
    }
}
