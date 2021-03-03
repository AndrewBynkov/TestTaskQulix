using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quilix.TestTask.Data.Models;
using Quilix.TestTask.DataAppWeb.ViewModels;
using Quilix.TestTask.Logic.Interfaces;
using System;
using System.Collections.Generic;

namespace Quilix.TestTask.DataAppWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly ICompanyManager _companyManager;
        private readonly ICompanyEmployeeManager _companyEmployeeManager;

        public EmployeeController(
            IEmployeeManager employeeManager,
            ICompanyManager companyManager,
            ICompanyEmployeeManager companyEmployeeManager)
        {
            _employeeManager = employeeManager ?? throw new ArgumentNullException(nameof(employeeManager));
            _companyManager = companyManager ?? throw new ArgumentNullException(nameof(companyManager));
            _companyEmployeeManager = companyEmployeeManager ?? throw new ArgumentNullException(nameof(companyEmployeeManager));
        }

        public ActionResult Index()
        {
            var employees = _employeeManager.GetAllEmployees();
            var companyEmployees = _companyEmployeeManager.GetAllCompanyEmployee();
            var companies =  _companyManager.GetAllCompany();

            // UNDONE: Проверить полученные данные из БД

            var employeesViewModels = new List<EmployeeViewModel>();
            foreach (var employee in employees)
            {
                var companyEmployee = companyEmployees.Find(c => c.EmployeeId ==  employee.Id);
                var company = companies.Find(c => c.Id == companyEmployee.CompanyId);

                employeesViewModels.Add(new EmployeeViewModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    SecondName = employee.SecondName,
                    HiringDate = employee.HiringDate,
                    Position = employee.Position,
                    CompanyName = company.Name
                });
            }

            return View(employeesViewModels);
        }

        public ActionResult Details(int id)
        {
            var employee = _employeeManager.GetEmployeeData(id);
            var companyId = _companyEmployeeManager.GetCompanyIdByEmployeeId(employee.Id);
            var company = _companyManager.GetCompanyData(companyId);

            // UNDONE: Проверить полученные данные из БД

            var employeeViewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                SecondName = employee.SecondName,
                HiringDate = employee.HiringDate,
                Position = employee.Position,
                CompanyName = company.Name
            };

            return View(employeeViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var companies = _companyManager.GetAllCompany();

            // UNDONE: bug

            var companiesList = new SelectList(companies, "Id", "Name");
            ViewBag.Companies = companiesList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                // UNDONE: Необходимо использовать DTO модель

                var employee = new Employee
                {
                    Name = employeeViewModel.Name,
                    Surname = employeeViewModel.Surname,
                    SecondName = employeeViewModel.SecondName,
                    HiringDate = employeeViewModel.HiringDate,
                    Position = employeeViewModel.Position,
                };

                _employeeManager.AddEmployee(employee);

                var lastEmployeeId = _employeeManager.GetLastId();

                var employeeCompany = new CompanyEmployee
                {
                    EmployeeId = lastEmployeeId,
                    CompanyId = employeeViewModel.CompanyId,
                };

                _companyEmployeeManager.AddCompanyEmployee(employeeCompany);

                // UNDONE: Обработать потенциальную ошибку при операции с данными

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = _employeeManager.GetEmployeeData(id);
            var companyId = _companyEmployeeManager.GetCompanyIdByEmployeeId(employee.Id);
            var companies = _companyManager.GetAllCompany();

            // UNDONE: Проверить полученные данные из БД

            var companiesList = new SelectList(companies, "Id", "Name");
            ViewBag.Companies = companiesList;

            var employeeViewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                SecondName = employee.SecondName,
                HiringDate = employee.HiringDate,
                Position = employee.Position,
                CompanyId = companyId,
            };

            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            try
            {
                var employee = new Employee
                {
                    Id = employeeViewModel.Id,
                    Name = employeeViewModel.Name,
                    Surname = employeeViewModel.Surname,
                    SecondName = employeeViewModel.SecondName,
                    HiringDate = employeeViewModel.HiringDate,
                    Position = employeeViewModel.Position,
                };

                _employeeManager.UpdateEmployee(employee);

                var companyEmployeeId = _companyEmployeeManager.GetIdByByEmployeeId(employee.Id);

                var employeeCompany = new CompanyEmployee
                {
                    Id = companyEmployeeId,
                    EmployeeId = employee.Id,
                    CompanyId = employeeViewModel.CompanyId,
                };

                _companyEmployeeManager.UpdateCompanyEmployee(employeeCompany);

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
        public ActionResult Delete(int id)
        {
            try
            {
                // UNDONE: Запрет возможности удалить базовую компанию
                if (id != 1)
                {
                    var employee = _employeeManager.GetEmployeeData(id);
                    var companyEmployeeId = _companyEmployeeManager.GetIdByByEmployeeId(employee.Id);

                    _companyEmployeeManager.DeleteCompanyEmployee(companyEmployeeId);
                    _employeeManager.DeleteEmployee(id);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
