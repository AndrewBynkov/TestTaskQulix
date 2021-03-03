using Quilix.TestTask.Data.Models;
using System.Collections.Generic;

namespace Quilix.TestTask.Logic.Interfaces
{
    public interface ICompanyManager
    {
        // UNDONE: При возможности LINQ лучше использовать IEnumerable
        List<Company> GetAllCompany();

        void AddCompany(Company company);

        void UpdateCompany(Company company);

        Company GetCompanyData(int id);

        void DeleteCompany(int id);
    }
}