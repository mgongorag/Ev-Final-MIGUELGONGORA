using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest.Entities
{
    public class Country
    {
        private int id { get; set; }
        private string country { get; set; }
        private string capital { get; set; }
        private int population { set; get; }
        private string president { get; set; }
        private string language { get; set; }
        private string coin { get; set; }
        private string dateOfAdmission { get; set; }

    }
}
