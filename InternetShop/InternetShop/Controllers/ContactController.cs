using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class ContactController : Controller
    {
        readonly ProductService _service;
        public ContactController(ProductService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service);
        }
    }
}
