using CS3750Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CS3750Project.Controllers
{
    public class WelcomeController : Controller
    {
        private CS3750ProjectContext _context;

        public WelcomeController(CS3750ProjectContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string email)
        {
            Models.User user = await _context.User.FindAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
    }
}
