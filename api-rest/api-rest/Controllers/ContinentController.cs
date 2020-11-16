using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_rest.Controllers
{
    public class ContinentController : ApiController
    {
        [HttpGet]
        [Route("api/getContinents")]
        public DataTable getCountries()
        {
            return Data.DataContinent.getContinents();
        }
    }
}
