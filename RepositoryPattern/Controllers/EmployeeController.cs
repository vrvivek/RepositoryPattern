using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository(new EmployeeDBContext());
        }

        //public EmployeeController(IEmployeeRepository employeeRepository)
        //{
        //    _employeeRepository = employeeRepository;
        //}

        public IActionResult Index()
        {
            var model = _employeeRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Insert(model);
                _employeeRepository.Save();
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditEmployee(int NumE_ID)
        {
            Employee model = _employeeRepository.GetById(NumE_ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(model);
                _employeeRepository.Save();
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int NumE_ID)
        {
            Employee model = _employeeRepository.GetById(NumE_ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int NumE_ID)
        {
            _employeeRepository.Delete(NumE_ID);
            _employeeRepository.Save();
            return RedirectToAction("Index", "Employee");
        }
    }
}
