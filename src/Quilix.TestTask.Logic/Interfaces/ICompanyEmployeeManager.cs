﻿using Quilix.TestTask.Data.Models;
using System.Collections.Generic;

namespace Quilix.TestTask.Logic.Interfaces
{
    public interface ICompanyEmployeeManager
    {
        // UNDONE: При возможности LINQ лучше использовать IEnumerable
        List<CompanyEmployee> GetAllCompanyEmployee();

        void AddCompanyEmployee(CompanyEmployee company);

        void UpdateCompanyEmployee(CompanyEmployee company);

        CompanyEmployee GetCompanyEmployeeData(int id);

        void DeleteCompanyEmployee(int id);

        int GetCompanyIdByEmployeeId(int employeeId);

        int GetIdByByEmployeeId(int employeeId);
    }
}