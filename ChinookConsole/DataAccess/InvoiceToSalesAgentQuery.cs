using ChinookConsole.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsole
{
    class InvoiceToSalesAgentQuery
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public List<InvoiceToSalesAgent> GetInvoiceBySalesAgent()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT Employee.FirstName, Employee.LastName, Invoice.InvoiceId
             from Invoice
                join Customer on Invoice.CustomerId = Customer.CustomerId
                join Employee on Customer.CustomerId = Employee.EmployeeId";

                var reader = cmd.ExecuteReader();

                var invoices = new List<InvoiceToSalesAgent>();

                while (reader.Read())
                {
                    var invoice = new InvoiceToSalesAgent
                    {
                        InvoiceId = int.Parse(reader["InvoiceId"].ToString()),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };
                    invoices.Add(invoice);

                }
                return invoices;
            }
        }       
    }
}

