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
        public IActionResult Upload()
        {
            return RedirectToAction("Index", "Upload");
        }

    }
}
