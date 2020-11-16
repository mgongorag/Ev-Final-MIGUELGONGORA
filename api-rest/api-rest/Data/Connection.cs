using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace api_rest.Data
{
    public class Connection
    {
        private static string user = WebConfigurationManager.AppSettings["user"].ToString();
        private static string password = WebConfigurationManager.AppSettings["password"].ToString();
        private static string server = WebConfigurationManager.AppSettings["server"].ToString();
        private static string database = WebConfigurationManager.AppSettings["database"].ToString();

        public static string getConnectionString()
        {
            return "Persist Security Info = false; User ID = '" + user
                        + "'; Password = '" + password
                        + "'; Initial Catalog = '" + database
                        + "'; Server = '" + server + "'";
        }

        public static SqlCommand createCommandSP(String SP)
        {
            string strConnection = Connection.getConnectionString();
            SqlConnection MyConString = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand(SP, MyConString);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            return command;
        }

        public static DataTable execCommandSelect(SqlCommand command)
        {
            DataTable dt = new DataTable();
            try
            {
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Dispose();
                command.Connection.Close();
            }
            return dt;
        }



    }
}