using Microsoft.AspNetCore.Mvc;
using CS3750Project.Models;
using Microsoft.EntityFrameworkCore;
using CS3750Project.Data;
using System.Dynamic;

namespace CS3750Project.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly CS3750ProjectContext _context;

        public AssignmentController(CS3750ProjectContext context)
        {
            _context = context;
        }
        public IActionResult Index(int classId)
        {
        
            Class course = _context.Class.FirstOrDefault(c => c.Id == classId);
            var assignments = course.Assignments;

            if(assignments == null)
            {
                assignments = new List<Assignment>();
            }


            Assignment assignment = _context.Assignment.FirstOrDefault(c => c.ClassId == classId);


            dynamic model = new ExpandoObject();
            model.Course = course;
            model.Assignments = assignments;
            model.Assignment = assignment;

            return View(model);
        }

        [HttpGet]
        public IActionResult Create(int classId)
        {
            // example only
            Assignment subject = new Assignment();
            {
                subject.ClassId = classId;
            };

            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Assignment assignmentModel)
        {

            _context.Assignment.Add(assignmentModel);
            _context.SaveChanges();

            Class course = _context.Class.FirstOrDefault(c => c.Id == assignmentModel.ClassId);

            course.Assignments.Add(assignmentModel);

            return Index(assignmentModel.ClassId) ; 

        }




        public class MainPageModel
        {
            public Class? Course { get; set; }
            public List<Assignment>? Assignments { get; set; }

            public Assignment Assignment { get; set; }

        }

    }
}
