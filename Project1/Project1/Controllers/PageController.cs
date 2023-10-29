using Microsoft.AspNetCore.Mvc;

namespace Project1.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Page()
        {
            return View();
        }

    }
}
