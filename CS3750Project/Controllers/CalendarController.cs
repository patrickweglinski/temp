using Microsoft.AspNetCore.Mvc;

namespace CS3750Project.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            // Retrieve event data from the database
           // List<CalendarEvent> events = GetEventsFromDatabase();

            // Pass the event data to the view
           //

            return View();
        }

       /* private List<CalendarEvent> GetEventsFromDatabase()
        {
            // Logic to fetch events from the database
            // You can use Entity Framework or any other data access method here
            // Return a List<CalendarEvent> containing event data
        }*/
    }
}
