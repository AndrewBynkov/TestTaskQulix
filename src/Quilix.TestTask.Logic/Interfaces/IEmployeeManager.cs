using Quilix.TestTask.Data.Models;
using System.Collections.Generic;

namespace Quilix.TestTask.Logic.Interfaces
{
    public interface IEmployeeManager
    {
        IEnumerable<Employee> GetAllEmployees();

        void AddEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        Employee GetEmployeeData(int id);

        void DeleteEmployee(int id);
    }
}