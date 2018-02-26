using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinookConsole.DataAccess;

namespace ChinookConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var invoiceQuery = new InvoiceQuery();
            var invoices = invoiceQuery.GetInvoiceDetails();

            foreach (var invoice in invoices)
            {
                Console.WriteLine($"The invoice totaling {invoice.Total} was shipped to {invoice.Company} in {invoice.Country}.  Their Sales agent is {invoice.FirstName} {invoice.LastName}.");
            }
            Console.ReadLine();

            var invoiceToSalesAgentQuery = new InvoiceToSalesAgentQuery();
            var invoices2 = invoiceToSalesAgentQuery.GetInvoiceBySalesAgent();

            foreach (var invoice in invoices2)
            {
                Console.WriteLine($"{invoice.FirstName} {invoice.LastName}'s invoice Id is {invoice.InvoiceId} ");
            }
            Console.ReadLine();



        }

       
    }
}
