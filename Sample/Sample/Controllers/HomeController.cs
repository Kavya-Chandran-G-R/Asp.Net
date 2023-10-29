using Microsoft.AspNetCore.Mvc;
using Sample.Data;
using Sample.Models;
using System.Diagnostics;

namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Table
        public IActionResult Table()
        {
            IEnumerable<Register> userlist = _db.Registers.ToList();
            return View(userlist);
        }
        #endregion

        #region Form
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form(Register register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);

            }
            _db.Registers.Add(register);
            _db.SaveChanges();
            TempData["SweetSuccess"] = "Successfully Created";
            return RedirectToAction("Form");
        }
        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            if(id == 0|| id==null)
            {
                return RedirectToAction("Table");

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
            TempData["SweetSuccess"] = "Edited";
            return RedirectToAction("Table");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            if(id==0||id==null)
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
           
            var userdelete= _db.Registers.Find(id);
            if (userdelete==null)
            {
                return NotFound();
            }
            _db.Registers.Remove(userdelete);
            _db.SaveChanges();
            TempData["SweetWarning"] = "Deleted";
            return RedirectToAction("Table");
        }
        #endregion
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