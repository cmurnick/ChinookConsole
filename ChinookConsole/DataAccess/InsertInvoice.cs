using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsole.DataAccess
{
    class InsertInvoice
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public bool Insert(int customerId, string billingAddress, string billingCity, string billingState, string billingPostalCode, double total)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"INSERT INTO Invoice (
          
           CustomerId,
           InvoiceDate,
           BillingAddress,
           BillingCity,
           BillingState,
           BillingCountry,
           BillingPostalCode,
           Total)
     VALUES
           (
           @CustomerId,
           3/13/1981, 
           @BillingAddress, 
           @BillingCity, 
           @BillingState, 
           'USA', 
           @BillingPostalCode, 
           @Total)";

               

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int);
                customerIdParam.Value = customerId;
                cmd.Parameters.Add(customerIdParam);

                var billingAddressParam = new SqlParameter("@BillingAddress", SqlDbType.NVarChar);
                billingAddressParam.Value = billingAddress;
                cmd.Parameters.Add(billingAddressParam);

                var billingCityParam = new SqlParameter("@BillingCity", SqlDbType.NVarChar);
                billingCityParam.Value = billingCity;
                cmd.Parameters.Add(billingCityParam);

                var billingStateParam = new SqlParameter("@BillingState", SqlDbType.NVarChar);
                billingStateParam.Value = billingState;
                cmd.Parameters.Add(billingStateParam);

                var billingPostalCodeParam = new SqlParameter("@BillingPostalCode", SqlDbType.NVarChar);
                billingPostalCodeParam.Value = billingPostalCode;
                cmd.Parameters.Add(billingPostalCodeParam);

                var totalParam = new SqlParameter("@Total", SqlDbType.Decimal);
                totalParam.Value = total;
                cmd.Parameters.Add(totalParam);

                connection.Open();

                var result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }
    }
}
