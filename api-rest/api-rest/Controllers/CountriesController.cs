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
            return Data.DataCountry.getCountries(country);
        }

    }
}
