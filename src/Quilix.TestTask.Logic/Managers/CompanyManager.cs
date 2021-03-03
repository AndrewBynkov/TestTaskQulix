using Quilix.TestTask.App.Utility;
using Quilix.TestTask.Data.Models;
using Quilix.TestTask.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quilix.TestTask.Logic.Managers
{
    public class CompanyManager : ICompanyManager
    {
        public Company GetCompanyData(int id)
        {
            var company = new Company();

            using (var sqlConnection = new SqlConnection(ConnectionString.CName))
            {
                var sqlQuery = "SELECT * FROM [organization].[Companies] WHERE Id= " + id;
                var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    company.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    company.Name = sqlDataReader["Name"].ToString();
                    company.OrganizationForm = sqlDataReader["OrganizationForm"].ToString();

                }
            }
            return company;
        }

        public void UpdateCompany(Company company)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.CName))
            {
                var sqlCommand = new SqlCommand("spUpdateCompany", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", company.Id);
                sqlCommand.Parameters.AddWithValue("@Name", company.Name);
                sqlCommand.Parameters.AddWithValue("@OrganizationForm", company.OrganizationForm);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        void ICompanyManager.AddCompany(Company company)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.CName))
            {
                var sqlCommand = new SqlCommand("spAddCompany", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Name", company.Name);
                sqlCommand.Parameters.AddWithValue("@OrganizationForm", company.OrganizationForm);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        void ICompanyManager.DeleteCompany(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.CName))
            {
                var sqlCommand = new SqlCommand("spDeleteCompany", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        List<Company> ICompanyManager.GetAllCompany()
        {
            var companees = new List<Company>();
            using (var sqlConnection = new SqlConnection(ConnectionString.CName))
            {
                var cmd = new SqlCommand("spGetAllCompany", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                var sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    var company = new Company();
                    company.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    company.Name = sqlDataReader["Name"].ToString();
                    company.OrganizationForm = sqlDataReader["OrganizationForm"].ToString();

                    companees.Add(company);
                }
                sqlConnection.Close();
            }

            return companees;
        }
    }
}