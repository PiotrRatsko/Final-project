using InternetShop.Domain.Repositories;
using InternetShop.Models;
using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class ContactController : Controller
    {
        readonly IStoreRepository _repo;
        public ContactController(IStoreRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.TotalQuantity = _repo.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            return View();
        }


        //public IActionResult SendMessage()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Index(EmailModel emailModel)
        {
            if (ModelState.IsValid)
            {
                //EmailService emailService = new EmailService();
                //await emailService.SendEmailAsync("green@tut.by", "Тема письма kkkkkk", "Тест письма: тест!");
                ModelState.AddModelError("", "Letter was sent");
            }

            return View(emailModel);
        }
    }
}
