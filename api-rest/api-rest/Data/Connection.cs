using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace api_rest.Data
{
    public class Connection
    {
        private static string user = "sa";
        private static string password = "admin";
        private static string server = "GODLIKE";
        private static string database = "BDExFinal";

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