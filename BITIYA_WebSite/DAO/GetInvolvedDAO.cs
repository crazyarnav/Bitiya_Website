using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BITIYA_WebSite.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BITIYA_WebSite.DAO
{
    public class GetInvolvedDAO
    {
        public static void Save(Person p)
        {
            string name = "ApplicationServices";
            string arvix_connect = getConnectionStringByName(name);

            SqlConnection myConnection = new SqlConnection(arvix_connect);
            
            string sp_Name = "up_insertGetInvolved";

            SqlCommand myCommand = new SqlCommand(sp_Name, myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter fName = new SqlParameter("@FirstName", p.Firstname ?? string.Empty);
            myCommand.Parameters.Add(fName);

            SqlParameter lName = new SqlParameter("@LastName", p.Lastname ?? string.Empty);
            myCommand.Parameters.Add(lName);

            SqlParameter address = new SqlParameter("@Address", p.Address ?? string.Empty);
            myCommand.Parameters.Add(address);

            SqlParameter city = new SqlParameter("@City", p.City ?? string.Empty);
            myCommand.Parameters.Add(city);

            SqlParameter state = new SqlParameter("@State", p.State ?? string.Empty);
            myCommand.Parameters.Add(state);

            SqlParameter zip = new SqlParameter("@zip", p.Zip ?? string.Empty);
            myCommand.Parameters.Add(zip);

            SqlParameter email = new SqlParameter("@Email", p.Email ?? string.Empty);
            myCommand.Parameters.Add(email);

            SqlParameter phone = new SqlParameter("@Phone", p.Phone ?? string.Empty);
            myCommand.Parameters.Add(phone);

            SqlParameter avail = new SqlParameter("@Availability", p.Availability ?? string.Empty);
            myCommand.Parameters.Add(avail);

            SqlParameter events = new SqlParameter("@Events", p.Volunteer ?? string.Empty);
            myCommand.Parameters.Add(events);

            SqlParameter funds = new SqlParameter("@Funds", p.Fundraising ?? string.Empty);
            myCommand.Parameters.Add(funds);

            SqlParameter skills = new SqlParameter("@Skills", p.Interests ?? string.Empty);
            myCommand.Parameters.Add(skills);

            SqlParameter ideas = new SqlParameter("@Ideas", p.Suggestions ?? string.Empty);
            myCommand.Parameters.Add(ideas);

            myConnection.Open();

            int noofrows = myCommand.ExecuteNonQuery();
            myConnection.Close();
            
        }

        // Retrieves a connection string by name.
        // Returns null if the name is not found.
        static string getConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}