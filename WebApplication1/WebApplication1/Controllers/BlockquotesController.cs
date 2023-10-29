using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class BlockquotesController : Controller
    {
        public IActionResult Blockquotes()
        {
            return View();
        }
    }
}
