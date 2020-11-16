using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_rest.Entities;

namespace api_rest.Controllers
{
    public class CountriesController : ApiController
    {
      
       [HttpGet]
       [Route("api/getCountries")]
       public DataTable getCountries()
        {
            return Data.DataCountry.getCountries();
        }

        [HttpPost]
        [Route("api/getCountryById")]
        public DataTable getCountryById(Country country)
        {
            return Data.DataCountry.getCountry(country);
        }

        [HttpPost]
        [Route("api/getCountryByContinent")]
        public DataTable getCountriesByContinent(Country country)
        {
            return Data.DataCountry.getCountryByContinent(country);
        }


        [HttpPost]
        [Route("api/updateCountry")]
        public DataTable updateCountry(Country country)
        {
            return Data.DataCountry.updateCountry(country);
        }

        [HttpPost]
        [Route("api/addCountry")]
        public DataTable addCountry(Country country)
        {
            return Data.DataCountry.addCountry(country);
        }

        [HttpPost]
        [Route("api/deleteCountry")]
        public DataTable deleteCountry(Country country)
        {
            return Data.DataCountry.deleteCountry(country);
        }

    }
}
