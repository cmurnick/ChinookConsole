using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsole.DataAccess.Models
{
    internal class InvoiceToSalesAgent
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int InvoiceId { get; set; }
    }

    internal class AllInvoice
    {
        public double Total { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
