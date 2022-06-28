using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class AggregateHomeInfoResponse
    {
        public List<String> Cities { get; set; }
        public List<string> LandTypesFromHomes { get; set; }
        public List<string> GroupedCities { get; set; }
        public List<string> LandType { get; set; }
        public string ListingCount { get; set; }

    }
}
