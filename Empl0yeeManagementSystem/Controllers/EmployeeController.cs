using Empl0yeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Empl0yeeManagementSystem.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"SELECT * FROM Employee";
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlDataAdapter.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        public string Post(Employee employee)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"INSERT INTO Employee(Name, Salary, DOJ,Phone) VALUES('" +employee.Name + @"', '" + employee.Salary
                    + @"', '" + employee.DOJ + @"', '" + employee.Phone + @"')";
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlDataAdapter.Fill(table);
                }

                return "Employee registration is successfully";
            }
            catch (Exception)
            {
                return "Failed to registration Employee";
            }
        }

    }
}
