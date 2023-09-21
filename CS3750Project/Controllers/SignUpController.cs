using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CS3750Project.Data;
using CS3750Project.Models;

namespace CS3750Project.Controllers
{
    public class SignUpController : Controller
    {
        private readonly CS3750ProjectContext _context;

        public SignUpController(CS3750ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [BindProperty]
        public new User User { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.User == null || User == null)
            {
                return View("Index");
            }

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Welcome", new { email = User.Email });
        }
    }
}
