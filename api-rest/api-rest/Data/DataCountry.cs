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

        public static DataTable getCountries()
        {
            dt.Clear();
            SqlCommand command = Connection.createCommandSP("SPGetAllCountries");
            dt = Connection.execCommandSelect(command);

            return dt;
        }

        public static DataTable getCountry(Country country)
        {
            dt.Clear();
            SqlCommand command = Connection.createCommandSP("SPGetCountryById");
            command.Parameters.AddWithValue("@_IdCountry", country.id);
            dt = Connection.execCommandSelect(command);
            return dt;
        }


        public static DataTable deleteCountry(Country country)
        {
            dt.Clear();
            SqlCommand command = Connection.createCommandSP("SPDeleteCountry");
            command.Parameters.AddWithValue("@_IdCountry", country.id);
            dt = Connection.execCommandSelect(command);
            return dt;
        }

        public static DataTable getCountryByContinent(Country country)
        {
            dt.Clear();
            SqlCommand command = Connection.createCommandSP("SPGetCountriesByContinent");
            command.Parameters.AddWithValue("@_IdContinent", country.idContinent);
            dt = Connection.execCommandSelect(command);
            return dt;
        }

        public static DataTable updateCountry(Country country)
        {
            dt.Clear();
            SqlCommand command = Connection.createCommandSP("SPUpdateCountry");
            command.Parameters.AddWithValue("@_IdPais", country.id);
            command.Parameters.AddWithValue("@_IdContinente", country.idContinent);
            command.Parameters.AddWithValue("@_TxtPais", country.country);
            command.Parameters.AddWithValue("@_TxtCapital", country.capital);
            command.Parameters.AddWithValue("@_IntAnioIndependencia", country.yearOfIndependence);
            command.Parameters.AddWithValue("@_IntPoblacion", country.population);
            command.Parameters.AddWithValue("@_TxtPresidenteActual", country.president);
            command.Parameters.AddWithValue("@_TxtIdiomaOficial", country.language);
            command.Parameters.AddWithValue("@_TxtMoneda", country.coin);

            dt = Connection.execCommandSelect(command);
            return dt;


        }

        public static DataTable addCountry(Country country)
        {
            dt.Clear();
            SqlCommand command = Connection.createCommandSP("SPAddCountry");
            command.Parameters.AddWithValue("@_IdContinente", country.idContinent);
            command.Parameters.AddWithValue("@_TxtPais", country.country);
            command.Parameters.AddWithValue("@_TxtCapital", country.capital);
            command.Parameters.AddWithValue("@_IntAnioIndependencia", country.yearOfIndependence);
            command.Parameters.AddWithValue("@_IntPoblacion", country.population);
            command.Parameters.AddWithValue("@_TxtPresidenteActual", country.president);
            command.Parameters.AddWithValue("@_TxtIdiomaOficial", country.language);
            command.Parameters.AddWithValue("@_TxtMoneda", country.coin);

            dt = Connection.execCommandSelect(command);
            return dt;
        }
    }
}