using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CS3750Project.Controllers
{
    public class AccountController:Controller
    {

        public async Task<IActionResult> Index()
        {
            
            return View();
        }
    }
}
