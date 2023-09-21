using CS3750Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CS3750Project.Controllers
{
    public class LoginController : Controller
    {

        private readonly CS3750ProjectContext _context;

        public LoginController(CS3750ProjectContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[BindProperty]
        //public string Email { get; set; }
        //[BindProperty]
        //public string Password { get; set; }
        [HttpPost]
        public async Task<IActionResult> OnPostAsync(string Email, string Password) 
        {
            var user = await _context.User
                .Where (x => x.Email == Email && x.Password == Password)
                .FirstOrDefaultAsync ();

            if (user == null)
            {
                return View();
            }
            
            HttpContext.Session.SetString("GetUser", user.Email);
            return RedirectToAction("Index", "Welcome", new { email = user.Email });
        }
    }
}
