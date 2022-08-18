using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpNunit.JSON.DeserializeJSONResponse
{
    public class PlaceDetailsResponse
    {
        public string postcode { get; set; }
        public string country { get; set; }
        public string countryabbreviation { get; set; }

        public List<PlaceDetail>places { get; set; }

        public class PlaceDetail
        {
            public string place_name { get; set; }
            public string longitude { get; set; }
            public string state { get; set; }
        }

    }
}
