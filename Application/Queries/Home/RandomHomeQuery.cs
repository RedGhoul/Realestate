using MediatR;
using RealEstate.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Home
{
    public class RandomHomeQuery : IRequest<List<HomeDto>>
    {
        public int randomHomeCount { get; set; }
    }
}
