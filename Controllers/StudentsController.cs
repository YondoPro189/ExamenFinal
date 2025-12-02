using Microsoft.AspNetCore.Mvc;
using ExamenFinal.Models;

namespace ExamenFinal.Controllers
{
    public class StudentsController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Name = "Ana López", Career = "Ingeniería", Average = 90 },
            new Student { Name = "Luis Pérez", Career = "Sistemas", Average = 85 }
        };

        public IActionResult Index()
        {

            List<Student> top = null;

            try
            {
                top = students
                .OrderByDescending(x => x.Name)
                .Take(10)
                .ToList();

            }
            catch
            {
                top = null;
            }
            
            ViewBag.Top3 = null;

            return View(students);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (student.Average < 0 || student.Average > 100)
            {
                ModelState.AddModelError("", "El promedio debe ser entre 0 y 100");
                return View(student);
            }

            students.Add(student);

            return RedirectToAction("Index");
        }

    }
}
