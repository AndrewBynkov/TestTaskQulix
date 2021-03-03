using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quilix.TestTask.Data.Models;
using Quilix.TestTask.DataAppWeb.ViewModels;
using Quilix.TestTask.Logic.Interfaces;
using Quilix.TestTask.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quilix.TestTask.AppWeb.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyManager _companyManager;
        private readonly ICompanyEmployeeManager _companyEmployeeManager;

        public CompanyController(
            ICompanyManager companyManager,
            ICompanyEmployeeManager companyEmployeeManager)
        {
            _companyManager = companyManager ?? throw new ArgumentNullException(nameof(companyManager));
            _companyEmployeeManager = companyEmployeeManager ?? throw new ArgumentNullException(nameof(companyEmployeeManager));
        }

        public ActionResult Index()
        {
            var companies = _companyManager.GetAllCompany();

            // UNDONE: Проверить полученные данные из БД

            // mapping
            var companiesViewModels = new List<CompanyViewModel>();
            foreach (var company in companies)
            {
                companiesViewModels.Add(new CompanyViewModel
                {
                    Id = company.Id,
                    Name = company.Name,
                    OrganizationForm = company.OrganizationForm,
                });
            }

            return View(companiesViewModels);
        }

        public ActionResult Details(int id)
        {
            var company = _companyManager.GetCompanyData(id);

            // UNDONE: Проверить полученные данные из БД

            var companyViewModel = new CompanyViewModel
            {
                Id = company.Id,
                Name = company.Name,
                OrganizationForm = company.OrganizationForm,
            };

            return View(companyViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyViewModel companyViewModel)
        {
            if (ModelState.IsValid)
            {
                // UNDONE: Необходимо использовать DTO модель

                var company = new Company
                {
                    Id = companyViewModel.Id,
                    Name = companyViewModel.Name,
                    OrganizationForm = companyViewModel.OrganizationForm,
                };

                _companyManager.AddCompany(company);

                // UNDONE: Обработать потенциальную ошибку при операции с данными

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var company = _companyManager.GetCompanyData(id);

            // UNDONE: Проверить полученные данные из БД

            var companyViewModel = new CompanyViewModel
            {
                Id = company.Id,
                Name = company.Name,
                OrganizationForm = company.OrganizationForm,
            };

            return View(companyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyViewModel companyViewModel)
        {
            if (ModelState.IsValid)
            {
                var company = new Company
                {
                    Id = companyViewModel.Id,
                    Name = companyViewModel.Name,
                    OrganizationForm = companyViewModel.OrganizationForm,
                };

                _companyManager.UpdateCompany(company);

                // UNDONE: Обработать потенциальную ошибку при операции с данными

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
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
                    var companyEmployees = _companyEmployeeManager.GetAllCompanyEmployee();
                    var isExist = companyEmployees.FindAll(c => c.CompanyId == id);

                    if (isExist.Count > 0)
                    {
                        // UNDONE: Продумать View для запрета операции

                        return RedirectToAction(nameof(Index));
                    }

                    _companyManager.DeleteCompany(id);

                    // UNDONE: Обработать потенциальную ошибку при операции с данными
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
