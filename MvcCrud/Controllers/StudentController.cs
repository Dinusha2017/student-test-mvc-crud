using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> CreateNewStudent(Student student) 
        { 
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();

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

        [HttpPost]
        [Route("/{studentId}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditStudent(int studentId, Student updatedStudent)
        {
            Student student = _dbContext.Students.Find(studentId);
            student.Name = updatedStudent.Name;
            student.City = updatedStudent.City;
            student.Address = updatedStudent.Address;
            student.Fees = updatedStudent.Fees;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}