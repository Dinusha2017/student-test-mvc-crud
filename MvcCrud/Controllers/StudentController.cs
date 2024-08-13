using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace MvcCrud.Controllers
{
    [Route("[controller]/[action]")]
    public class StudentController : Controller
    {
        private static MvcCrudDbEntities _dbContext = new MvcCrudDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            List<Student> students = _dbContext.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewStudent(Student student) 
        { 
            _dbContext.Students.Add(student);
            _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/{studentId}")]
        public ActionResult Detail(int studentId)
        {
            Student student = _dbContext.Students.Find(studentId);
            return View(student);
        }

        [HttpGet]
        [Route("/{studentId}")]
        public ActionResult Edit(int studentId)
        {
            Student student = _dbContext.Students.Find(studentId);
            return View(student);
        }
    }
}