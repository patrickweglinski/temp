using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CS3750Project.Data;
using CS3750Project.Models;
using System.Net;

namespace CS3750Project.Controllers
{
    public class ProfileController : Controller
    {
        private readonly CS3750ProjectContext _context;

        public ProfileController(CS3750ProjectContext context)
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

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,Password,Email,BirthDate,AddressLineOne,AddressLineTwo,City,State,ZipCode,Link1,Link2,Link3")] User user)
        {
            if (id != user.Email)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Email))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Profile", new { email = user.Email });
            }

            return View(user);
        }

        private bool UserExists(string id)
        {
          return (_context.User?.Any(e => e.Email == id)).GetValueOrDefault();
        }
    }
}
