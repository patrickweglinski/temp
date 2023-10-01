using CS3750Project.Data;
using CS3750Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace CS3750Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Profile()
        {
            string id = HttpContext.Session.GetString("GetUser");
            return RedirectToAction("Index", "Profile", new { email = id });
        }
        public IActionResult Classes ()
        {
            string id = HttpContext.Session.GetString("GetUser");
            return RedirectToAction("Index", "Classes", new { email = id });
        }
        public IActionResult Upload()
        {
            return RedirectToAction("Index", "Upload");
        }

        public IActionResult Registration()
        {
            string id = HttpContext.Session.GetString("GetUser");
            return RedirectToAction("Index", "Registration", new { email = id });
        }
    }
}
