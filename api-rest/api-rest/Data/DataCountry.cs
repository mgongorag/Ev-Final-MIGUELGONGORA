using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using api_rest.Entities;

namespace api_rest.Data
{
    public class DataCountry
    {
        private static DataTable dt = new DataTable();

        public static DataTable getCountries(Country country)
        {
            dt.Clear();
            SqlCommand command = Connection.createCommandSP("SPGetAllCountries");
            dt = Connection.execCommandSelect(command);

            return dt;
        }
    }
}