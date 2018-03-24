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
    class UpdateId
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public bool UpdateId(int employeeId, string FirstName, string LastName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"

        UPDATE employee
        SET 
        LastName = nvarchar,
        FirstName, nvarchar
      
 WHERE employeeId = @employeeId";
    }

            var employeeIdParam = new SqlParameter("@EmployeeId", SqlDbType.Int);
            employeeIdParam.Value = employeeId;
            cmd.Parameters.Add(employeeIdParam);

            var firstNameParam = new SqlParameter("@FirstName", SqlDbType.Int);
            firstNameParam.Value = firstName;
            cmd.Parameters.Add(firstNameParam);

            var lastNameParam = new SqlParameter("@LastName", SqlDbType.Int);
            lastNameParam.Value = lastName;
            cmd.Parameters.Add(lastNameParam);
        }
