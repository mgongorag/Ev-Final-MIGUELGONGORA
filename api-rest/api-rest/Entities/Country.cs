using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest.Entities
{
    public class Country
    {
        public int id { get; set; }
        public int idContinent { get; set; }
        public string country { get; set; }
        public string capital { get; set; }
        public int population { set; get; }
        public int yearOfIndependence { get; set; }
        public string president { get; set; }
        public string language { get; set; }
        public string coin { get; set; }
        public string dateOfAdmission { get; set; }

    }
}
