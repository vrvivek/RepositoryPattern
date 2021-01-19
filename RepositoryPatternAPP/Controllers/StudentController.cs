using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternAPP.Data;
using RepositoryPatternAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternAPP.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Student> model = studentRepository.GetAllStudents().ToList();
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult AddEditStudent(Int32? id)
        {
            Student model = new Student();
            if (id.HasValue)
            {
                Student student = studentRepository.GetStudent(id.Value); if (student != null)
                {
                    model.ID = student.ID;
                    model.S_FirstName = student.S_FirstName;
                    model.S_LastName = student.S_LastName;
                    model.S_EnrollmentNo = student.S_EnrollmentNo;
                    model.S_Email = student.S_Email;
                }
            }
            return PartialView("~/Views/Student/AddEditStudent.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEditStudent(Int32? id, Student model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = (!id.HasValue || id == 0);
                    Student student = isNew ? new Student
                    {
                        AddedDate = DateTime.UtcNow
                    } : studentRepository.GetStudent(id.Value);
                    student.S_FirstName = model.S_FirstName;
                    student.S_LastName = model.S_LastName;
                    student.S_EnrollmentNo = model.S_EnrollmentNo;
                    student.S_Email = model.S_Email;
                    student.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        studentRepository.SaveStudent(student);
                    }
                    else
                    {
                        studentRepository.UpdateStudent(student);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteStudent(Int32 id)
        {
            Student model = studentRepository.GetStudent(id);
            return View("~/Views/Student/DeleteStudent.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteStudent(Int32 id, FormCollection form)
        {
            studentRepository.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}
