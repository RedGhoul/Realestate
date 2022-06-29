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
        List<int> homesToAvoid { get; set; }
        public int CacheTime { get; set; }
    }
}
