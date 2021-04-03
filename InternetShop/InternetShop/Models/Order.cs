namespace InternetShop.Models
{
    public class Order
    {
        public Cart Cart { get; set; }
        public string User { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
    }
}
