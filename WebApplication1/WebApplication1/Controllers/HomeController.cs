using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }
        #region Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Register register)
        {
            if(!ModelState.IsValid)
            {
                return View(register);

            }
            _db.Registers.Add(register);
            _db.SaveChanges();
            TempData["SweetSuccess"] = "Successfully Created";
            return RedirectToAction("Add");
        }
        public IActionResult Unit()
        {
            return View();
        }
        public IActionResult Home()
        {
            IEnumerable<Register> userlist = _db.Registers.ToList();
            return View(userlist);
           
        }
        public IActionResult Edit(int id)
        {
            if(id == 0||id == null)
            {
                return RedirectToAction("Home");
            }
            var a = _db.Registers.Find(id);
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]                                                                  
        public IActionResult Edit(Register register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            _db.Registers.Update(register);
            _db.SaveChanges();
            TempData["SweetSuccess"] = "Successfully Edited";
            return RedirectToAction("Home");
        }
        public IActionResult Delete(int id)
        {
             if (id == 0 || id == null)
            {
                return RedirectToAction("Table");
            }
            var a = _db.Registers.Find(id);

            return View(a);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {

            var userdelete = _db.Registers.Find(id);
            if (userdelete == null)
            {
                return NotFound();
            }
            _db.Registers.Remove(userdelete);
            _db.SaveChanges();
            TempData["SweetSuccess"] = "Successfully Deleted";
            return RedirectToAction("Home");
        }
        public IActionResult Button()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}