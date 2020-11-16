using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace api_rest.Data
{
    public class DataContinent
    {
        private static DataTable dt = new DataTable();

        public static DataTable getContinents()
        {
            dt.Clear();
            SqlCommand command = Connection.createCommandSP("SPGetContinents");
            dt = Connection.execCommandSelect(command);

            return dt;
        }
    }
}