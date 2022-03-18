using Students_ajax.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Students_ajax.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> _students;
        public StudentController()
        {
            _students = InitStudents._students;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(_students, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Student student)
        {
            student.Id = _students.Select(s => s.Id).Max() + 1;
            _students.Add(student);
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            return Json(_students.FirstOrDefault(s => s.Id == ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Student student)
        {
            var data = _students.FirstOrDefault(s => s.Id == student.Id);
            if (data != null)
            {
                data.Name = student.Name;
                data.MailAddress = student.MailAddress;
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var data = _students.FirstOrDefault(s => s.Id == ID);
            _students.Remove(data);
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}