using Quilix.TestTask.Data.Models;
using System.Collections.Generic;

namespace Quilix.TestTask.Logic.Interfaces
{
    public interface IEmployeeManager
    {
        // UNDONE: При возможности LINQ лучше использовать IEnumerable
        List<Employee> GetAllEmployees();

        void AddEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        Employee GetEmployeeData(int id);

        int GetLastId();

        void DeleteEmployee(int id);
    }
}