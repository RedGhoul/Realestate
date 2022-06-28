using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Home
{
    public class CountByCityQuery : IRequest<CountByCityResponse>
    {
        public int MinNumberCountOfHomes { get; set; }
        public int MaxNumberOfHomesToReturn { get; set; }
        public int cacheTimeSec { get; set; } = 500;
    }
}
