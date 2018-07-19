using Microsoft.AspNetCore.Mvc;

namespace NaturaShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}