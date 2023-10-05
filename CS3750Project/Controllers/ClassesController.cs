using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CS3750Project.Data;
using CS3750Project.Models;
using Microsoft.AspNetCore.Identity;

namespace CS3750Project.Controllers
{
    public class ClassesController : Controller
    {
        private readonly CS3750ProjectContext _context;

        public ClassesController(CS3750ProjectContext context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
              return _context.Class != null ? 
                          View(await _context.Class.ToListAsync()) :
                          Problem("Entity set 'CS3750ProjectContext.Class'  is null.");
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Class == null)
            {
                return NotFound();
            }

            var @class = await _context.Class
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }
            
            return View(@class);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InstructorId,ClassDept,ClassName,ClassNumber,CreditHours,Location,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,StartTime,EndTime")] Class @class)
        {
            // Retrieve user ID from session
            var userId = HttpContext.Session.GetString("GetUser");
            var loggedInUser = await _context.User.FindAsync(userId);

            if (string.IsNullOrEmpty(userId))
            {
                // Handle error when the user is not signed in
                ModelState.AddModelError("", "You must be signed in to create a class.");
                return View(@class);
            }

            if (loggedInUser != null && !loggedInUser.IsStudent)
            {
                // Assign the user ID as the instructor ID for the class
                @class.InstructorId = userId;
                @class.InstructorName = loggedInUser.FirstName + ' ' + loggedInUser.LastName;
            }
            else
            {
                // Handle error when the logged-in user is a student or not found
                ModelState.AddModelError("", "You must be an instructor to create a class.");
            }
                
            if (ModelState.IsValid)
            {
                // Check if the user is not a student (you can customize this check based on your logic)
                
                    // Add the class to the context and save changes
                    _context.Add(@class);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                
                
            }

             // If ModelState is not valid, return to the view with errors
            var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
            return View(@class);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Class == null)
            {
                return NotFound();
            }

            var @class = await _context.Class.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }
            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClassDept,ClassName,ClassNumber,CreditHours,Location,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,StartTime,EndTime")] Class @class)
        {
            if (id != @class.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@class);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Class == null)
            {
                return NotFound();
            }

            var @class = await _context.Class
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Class == null)
            {
                return Problem("Entity set 'CS3750ProjectContext.Class'  is null.");
            }
            var @class = await _context.Class.FindAsync(id);
            if (@class != null)
            {
                _context.Class.Remove(@class);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
          return (_context.Class?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
