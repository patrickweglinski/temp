using CS3750Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CS3750Project.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly CS3750ProjectContext _context;

        public RegistrationController(CS3750ProjectContext context)
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

        [HttpPost]
        public async Task<IActionResult> Register(string email)
        {
            Models.User user = await _context.User.FindAsync(email);
            if (user.IsStudent) 
            {
                user.IsStudent = false;
            }
            else
            {
                user.IsStudent = true;
            }
            
            _context.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Registration", new { email = user.Email });
        }

    }
}
