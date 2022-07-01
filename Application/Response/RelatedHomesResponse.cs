using RealEstate.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class RelatedHomesResponse
    {
        public List<List<HomeDto>> listsOfRelatedHomes { get; set; }
    }
}
