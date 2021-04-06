using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class ContactController : Controller
    {
        readonly StoreService _service;
        public ContactController(StoreService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service);
        }
    }
}
