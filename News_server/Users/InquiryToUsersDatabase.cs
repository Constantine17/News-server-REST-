using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Hosting;
using System.Diagnostics;

namespace News_server.Users
{
    public class InquiryToUsersDatabase
    {
        public bool LogIn(string user, string password)
        {
            if (user == "admin" && password == "admin") return true; // static login. If data base is't working;

            string directory = HostingEnvironment.ApplicationPhysicalPath;
            string sql = @"SELECT logins.Password FROM logins WHERE logins.Name = '"+ user+ "';";
            string userbase = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+directory+@"App_Data\Users_database.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(userbase);
            SqlCommand command = new SqlCommand(sql, connection); //crate comand

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if(!reader.HasRows){ reader.Close(); return false; }
            if (password == reader["Password"].ToString()) { reader.Close(); return true; }
            else { reader.Close(); return false; }
        }
    }
}