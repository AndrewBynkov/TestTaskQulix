
using Quilix.TestTask.App.Utility;
using Quilix.TestTask.Data.Enums;
using Quilix.TestTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Quilix.TestTask.Logic.CRUDoperation
{
    public class CrudOperations
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("spGetAllStudent", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                var sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    employee.Name = sqlDataReader["Name"].ToString();
                    employee.Surname = sqlDataReader["Surname"].ToString();
                    employee.SecondSurname = sqlDataReader["SecondSurname"].ToString();
                    employee.Position = (Positions)sqlDataReader["Position"];
                    employee.EmploymentDate =(DateTime)sqlDataReader["EmploymentDate"];

                    employees.Add(employee);
                }
                sqlConnection.Close();
            }
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand("spAddEmployee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("@Surame", employee.Surname);
                sqlCommand.Parameters.AddWithValue("@SecondSurname", employee.SecondSurname);
                sqlCommand.Parameters.AddWithValue("@Position", employee.Position);
                sqlCommand.Parameters.AddWithValue("@EmploymentDate", employee.EmploymentDate);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void UpdateStudent(Employee employee)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand("spUpdateStudent", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", employee.Id);
                sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("@Surame", employee.Surname);
                sqlCommand.Parameters.AddWithValue("@SecondSurname", employee.SecondSurname);
                sqlCommand.Parameters.AddWithValue("@Position", employee.Position);
                sqlCommand.Parameters.AddWithValue("@EmploymentDate", employee.EmploymentDate);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public Employee GetEmployeeData(int? id)
        {
            var employee = new Employee();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlQuery = "SELECT * FROM Employee WHERE Id= " + id;
                var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    employee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    employee.Name = sqlDataReader["Name"].ToString();
                    employee.Surname = sqlDataReader["Surname"].ToString();
                    employee.SecondSurname = sqlDataReader["SecondSurname"].ToString();
                    employee.Position = (Positions)sqlDataReader["Position"];
                    employee.EmploymentDate = (DateTime)sqlDataReader["Address"];
                }
            }
            return employee;
        }

        public void DeleteStudent(int? id)
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
    }
}
