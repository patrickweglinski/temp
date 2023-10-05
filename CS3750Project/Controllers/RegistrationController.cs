using CS3750Project.Data;
using CS3750Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace CS3750Project.Controllers
{
    //ViewData["Registered"] == "true"
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

            //Models.Registration registration = await _context.Registration.FindAsync(email);
            return View(await _context.Class.ToListAsync());
        }

        public async Task<IActionResult> Create()
       {
            string email = HttpContext.Session.GetString("GetUser");
            Registration registration = new Registration(email);
            
            ClassRegistration classRegistration = new ClassRegistration();
            classRegistration.StudentId = email;

            string test = "test@gmail.com";
            classRegistration.InstructorId = test;

            for (int i = 0; i < 10; i++)
            {
                registration.ClassId.Add(new ClassIdentify(i, email));
                registration.IsRegistered.Add(new Register(false, email));
            }
            
            
            _context.Registration.Add(registration);
            _context.ClassRegistration.Add(classRegistration);
            _context.ClassIdentify.AddRange(registration.ClassId);
            _context.Register.AddRange(registration.IsRegistered);


            await _context.SaveChangesAsync();
            Models.Registration tester = await _context.Registration.FindAsync(email);
            var classes = registration.IsRegistered;
            return RedirectToAction("Index", "Home", new { email });

        }


        [HttpPost]
        public async Task<IActionResult> Register(int Id)
        {
            string StudentId = HttpContext.Session.GetString("GetUser");

            Models.Registration register = await _context.Registration.Include(x => x.IsRegistered).Include(x => x.ClassId).FirstOrDefaultAsync(i => i.StudentId == StudentId);


            if (register.IsRegistered[Id].IsRegistered)
            {
                register.IsRegistered[Id].IsRegistered = false;
            }
            else
            {
                register.IsRegistered[Id].IsRegistered = true;
            }           
            
            _context.Update(register);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index", "Registration", new { email  = StudentId });
        }

    }
}
