using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinookConsole.DataAccess.Models;


namespace ChinookConsole
{
    class InvoiceQuery
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public  List<AllInvoice> GetInvoiceDetails()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT Invoice.Total, Customer.Company, Customer.Country, Employee.FirstName + ' ' + Employee.LastName 
                 from Invoice
                       join Customer on Customer.CustomerId = Invoice.CustomerId
                       join Employee on Employee.EmployeeId = Customer.CustomerId";

                var reader = cmd.ExecuteReader();

                var allInvoices = new List<AllInvoice>();

                while(reader.Read())
                {
                    var allInvoice = new AllInvoice
                    {
                        Total = double.Parse(reader["Total"].ToString()),
                        Company = reader["Company"].ToString(),
                        Country = reader["Country"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };

                    allInvoices.Add(allInvoice);
                }
                return allInvoices;
            }
        }
    }
}       
       