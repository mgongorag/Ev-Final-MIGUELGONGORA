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

        [HttpGet]
        [Route("api/getCountryById")]
        public DataTable getCountryById(Country country)
        {
            return Data.DataCountry.getCountry(country);
        }


        [HttpPut]
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

    }
}
