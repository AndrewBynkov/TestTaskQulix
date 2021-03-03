using Quilix.TestTask.App.Utility;
using Quilix.TestTask.Data.Enums;
using Quilix.TestTask.Data.Models;
using Quilix.TestTask.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Quilix.TestTask.Logic.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        public void AddEmployee(Employee employee)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand("spAddEmployee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("@Surname", employee.Surname);
                sqlCommand.Parameters.AddWithValue("@SecondName", employee.SecondName);
                sqlCommand.Parameters.AddWithValue("@Position", employee.Position);
                sqlCommand.Parameters.AddWithValue("@HiringDate", employee.HiringDate);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand("spDeleteEmployee", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("spGetAllEmployee", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                var sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    employee.Name = sqlDataReader["Name"].ToString();
                    employee.Surname = sqlDataReader["Surname"].ToString();
                    employee.SecondName = sqlDataReader["SecondName"].ToString();
                    employee.HiringDate = (DateTime)sqlDataReader["HiringDate"];
                    employee.Position = (PositionType)sqlDataReader["Position"];

                    employees.Add(employee);
                }
                sqlConnection.Close();
            }

            return employees;
        }

        public Employee GetEmployeeData(int id)
        {
            var employee = new Employee();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlQuery = "SELECT * FROM [organization].[Employees] WHERE Id= " + id;
                var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    employee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    employee.Name = sqlDataReader["Name"].ToString();
                    employee.Surname = sqlDataReader["Surname"].ToString();
                    employee.SecondName = sqlDataReader["SecondName"].ToString();
                    employee.Position = (PositionType)sqlDataReader["Position"];
                    employee.HiringDate = (DateTime)sqlDataReader["HiringDate"];
                }
            }
            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand("spUpdateEmployee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", employee.Id);
                sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("@Surname", employee.Surname);
                sqlCommand.Parameters.AddWithValue("@SecondName", employee.SecondName);
                sqlCommand.Parameters.AddWithValue("@Position", employee.Position);
                sqlCommand.Parameters.AddWithValue("@HiringDate", employee.HiringDate);
                
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public int GetLastId()
        {
            var employee = new Employee();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlQuery = "SELECT TOP(1) * FROM [organization].[Employees] ORDER BY Id DESC";
                var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    employee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    employee.Name = sqlDataReader["Name"].ToString();
                    employee.Surname = sqlDataReader["Surname"].ToString();
                    employee.SecondName = sqlDataReader["SecondName"].ToString();
                    employee.Position = (PositionType)sqlDataReader["Position"];
                    employee.HiringDate = (DateTime)sqlDataReader["HiringDate"];
                }
            }

            return employee.Id;
        }

        string connectionString = ConnectionString.CName;
    }
}
