using CS3750Project.Data;
using CS3750Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace CS3750Project.Controllers
{
    public class HomeController : Controller
    {

        private readonly CS3750ProjectContext _context;

        public HomeController(CS3750ProjectContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Class> classes = GetClassesFromDatabase();

            return View(classes);
        }

        private List<Class> GetClassesFromDatabase()
        {
            var classes = _context.Class
                .Select(c => new Class
                {
                    Id = c.Id,  
                    ClassName = c.ClassName,
                    ClassDept = c.ClassDept,
                    ClassNumber = c.ClassNumber,
                    Location = c.Location,
                    StartTime = c.StartTime,
                    Monday = c.Monday,
                    Tuesday = c.Tuesday,
                    Wednesday = c.Wednesday,
                    Thursday = c.Thursday,
                    Friday = c.Friday,
                    Saturday = c.Saturday,
                    Sunday = c.Sunday,
                    EndTime = c.EndTime
                })
                .ToList();

            // var classes2 = _context.Class.Where(x => x.InstructorId = 32).ToList();

            return classes;
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
        public IActionResult Classes()
        {
            string id = HttpContext.Session.GetString("GetUser");
            return RedirectToAction("Index", "Classes", new { email = id });
        }
        public IActionResult Upload()
        {
            return RedirectToAction("Index", "Upload");
        }

        public IActionResult Account()
        {
            return RedirectToAction("Index", "Account");
        }

        public IActionResult Registration()
        {
            string id = HttpContext.Session.GetString("GetUser");
            return RedirectToAction("Index", "Registration", new { email = id });
        }
        
        public IActionResult Calendar()
        {
            string id = HttpContext.Session.GetString("GetUser");
            return RedirectToAction("Index", "Calendar", new { email = id });
        }

    }
}