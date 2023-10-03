using Microsoft.AspNetCore.Mvc;
using CS3750Project.Models;
using CS3750Project.Data;

namespace CS3750Project.Controllers
{
    public class CalendarController : Controller
    {
        private readonly CS3750ProjectContext _context;

        public CalendarController(CS3750ProjectContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var classes = _context.Class.ToList();

            var events = new List<object>();

            foreach (var cls in classes)
            {
                var daysOfWeek = new List<int>();

                if (cls.Sunday) daysOfWeek.Add(0);
                if (cls.Monday) daysOfWeek.Add(1);
                if (cls.Tuesday) daysOfWeek.Add(2);
                if (cls.Wednesday) daysOfWeek.Add(3);
                if (cls.Thursday) daysOfWeek.Add(4);
                if (cls.Friday) daysOfWeek.Add(5);
                if (cls.Saturday) daysOfWeek.Add(6);

                foreach (var day in daysOfWeek)
                {
                    events.Add(new
                    {
                        title = cls.ClassName,
                        daysOfWeek = new List<int> { day },
                        startTime = cls.StartTime.ToString(@"hh\:mm"),
                        endTime = cls.EndTime.ToString(@"hh\:mm"),
                    });
                }
            }

            return View(events);
        }

       /* private List<CalendarEvent> GetEventsFromDatabase()
        {
            // Logic to fetch events from the database
            // You can use Entity Framework or any other data access method here
            // Return a List<CalendarEvent> containing event data
        }*/
    }
}
