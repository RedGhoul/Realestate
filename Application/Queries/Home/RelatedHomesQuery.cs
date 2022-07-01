using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Home
{
    public class RelatedHomesQuery : IRequest<RelatedHomesResponse>
    {
        public int cacheTime { get; set; } = 300;
        public int numberOfRelatedHomeLists { get; set; } = 2;
        public string relatedCity { get; set; }
        public int curCityId { get; set; }
    }
}
