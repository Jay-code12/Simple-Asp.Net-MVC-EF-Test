using Microsoft.AspNetCore.Mvc;
using School.Data;
using School.Models;

namespace School.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentDbContext _studentDb;
        public StudentController(StudentDbContext db) 
        {
            _studentDb = db;
        }

        public IActionResult Index()
        {
            List<Student> studentAllData = _studentDb.Students.ToList();
            return View(studentAllData);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student obj)
        {
            if (obj.Name == obj.Age.ToString())
            {
                ModelState.AddModelError("", "the display order cant be same as name");
            }
            if (ModelState.IsValid)
            {
                _studentDb.Students.Add(obj);
                _studentDb.SaveChanges();

                TempData["AlertMessage"] = "Student Record Created Successfully...";
                TempData["AlertColor"] = "success";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            Student obj = _studentDb.Students.Find(id);

            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            _studentDb.Students.Update(obj);
            _studentDb.SaveChanges();

            TempData["AlertMessage"] = obj.Name + " Record Edited Successfully...";
            TempData["AlertColor"] = "warning";

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            Student obj = _studentDb.Students.Find(id);
            _studentDb.Students.Remove(obj);
            _studentDb.SaveChanges();

            TempData["AlertMessage"] = obj.Name + " Record Deleted Successfully...";
            TempData["AlertColor"] = "danger";

            return RedirectToAction("Index");
        }
    }
}
