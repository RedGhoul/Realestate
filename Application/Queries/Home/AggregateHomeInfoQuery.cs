using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Home
{
    public class AggregateHomeInfoQuery : IRequest<AggregateHomeInfoResponse>
    {
        public int cacheTimeSec { get; set; } = 500;
        public bool Cities { get; set; }
        public bool LandTypesFromHomes { get; set; }
        public bool GroupedCities { get; set; }
        public bool LandType { get; set; }
        public bool ListingCount { get; set; }
    }
}
