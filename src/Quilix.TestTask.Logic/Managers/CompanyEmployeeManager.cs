using Quilix.TestTask.App.Utility;
using Quilix.TestTask.Data.Models;
using Quilix.TestTask.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Quilix.TestTask.Logic.Managers
{
    public class CompanyEmployeeManager : ICompanyEmployeeManager
    {
        public void AddCompanyEmployee(CompanyEmployee companyEmployee)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.CName))
            {
                var sqlCommand = new SqlCommand("spAddCompanyEmployee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@CompanyId", companyEmployee.CompanyId);
                sqlCommand.Parameters.AddWithValue("@EmployeeId", companyEmployee.EmployeeId);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void DeleteCompanyEmployee(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.CName))
            {
                var sqlCommand = new SqlCommand("spDeleteCompanyEmployee", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public List<CompanyEmployee> GetAllCompanyEmployee()
        {
            var companyEmployees = new List<CompanyEmployee>();
            using (var sqlConnection = new SqlConnection(ConnectionString.CName))
            {
                var cmd = new SqlCommand("spGetAllCompanyEmployee", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                var sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    var companyEmployee = new CompanyEmployee();
                    companyEmployee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    companyEmployee.CompanyId = Convert.ToInt32(sqlDataReader["CompanyId"]);
                    companyEmployee.EmployeeId = Convert.ToInt32(sqlDataReader["EmployeeId"]);

                    companyEmployees.Add(companyEmployee);
                }
                sqlConnection.Close();
            }

            return companyEmployees;
        }

        public CompanyEmployee GetCompanyEmployeeData(int id)
        {
            var companyEmployee = new CompanyEmployee();

            using (var sqlConnection = new SqlConnection(ConnectionString.CName))
            {
                var sqlQuery = "SELECT * FROM [organization].[CompanyEmployees] WHERE Id= " + id;
                var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    companyEmployee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    companyEmployee.CompanyId = Convert.ToInt32(sqlDataReader["CompanyId"]);
                    companyEmployee.EmployeeId = Convert.ToInt32(sqlDataReader["EmployeeId"]);
                }
            }
            return companyEmployee;
        }

        public int GetCompanyIdByEmployeeId(int employeeId)
        {
            var companyEmployee = new CompanyEmployee();

            using (var sqlConnection = new SqlConnection(ConnectionString.CName))
            {
                var sqlQuery = "SELECT * FROM [organization].[CompanyEmployees] WHERE EmployeeId= " + employeeId;
                var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    companyEmployee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    companyEmployee.CompanyId = Convert.ToInt32(sqlDataReader["CompanyId"]);
                    companyEmployee.EmployeeId = Convert.ToInt32(sqlDataReader["EmployeeId"]);
                }
            }
            return companyEmployee.CompanyId;
        }

        public int GetIdByByEmployeeId(int employeeId)
        {
            var companyEmployee = new CompanyEmployee();

            using (var sqlConnection = new SqlConnection(ConnectionString.CName))
            {
                var sqlQuery = "SELECT * FROM [organization].[CompanyEmployees] WHERE EmployeeId= " + employeeId;
                var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    companyEmployee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    companyEmployee.CompanyId = Convert.ToInt32(sqlDataReader["CompanyId"]);
                    companyEmployee.EmployeeId = Convert.ToInt32(sqlDataReader["EmployeeId"]);
                }
            }
            return companyEmployee.Id;
        }

        public void UpdateCompanyEmployee(CompanyEmployee companyEmployee)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.CName))
            {
                var sqlCommand = new SqlCommand("spUpdateCompanyEmployee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", companyEmployee.Id);
                sqlCommand.Parameters.AddWithValue("@CompanyId", companyEmployee.CompanyId);
                sqlCommand.Parameters.AddWithValue("@EmployeeId", companyEmployee.EmployeeId);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}