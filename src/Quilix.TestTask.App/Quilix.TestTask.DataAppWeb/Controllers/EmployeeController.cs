using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quilix.TestTask.Data.Models;
using Quilix.TestTask.Logic.Interfaces;
using System;
using System.Collections.Generic;

namespace Quilix.TestTask.DataAppWeb.Controllers
{
    public class EmployeeController : Controller
    {
        // UNDONE: Необходимо использовать ViewModels
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager ?? throw new ArgumentNullException(nameof(employeeManager));
        }

        public ActionResult Index()
        {
            var employees = _employeeManager.GetAllEmployees();
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            var employee = _employeeManager.GetEmployeeData(id);
            return View(employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                _employeeManager.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = _employeeManager.GetEmployeeData(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee, IFormCollection collection)
        {
            try
            {
                _employeeManager.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _employeeManager.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
