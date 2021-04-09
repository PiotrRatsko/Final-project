using InternetShop.Domain;
using InternetShop.Domain.Repositories;
using InternetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class ContactController : Controller
    {
        readonly DataManager _dataManager;
        public ContactController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.TotalQuantity = _dataManager.Repository.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            return View();
        }

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