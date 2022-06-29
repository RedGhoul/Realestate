using Application.Queries.Home;
using Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Queries;
using RealEstate.Data;
using RealEstate.Models.Dtos;
using RealEstate.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Home
{
    public class SearchHomesHandler : IRequestHandler<SearchHomeQuery, SearchHomeResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly CacheService _cache;
        private readonly IMapper _mapper;

        public SearchHomesHandler(IMapper mapper, ApplicationDbContext context, CacheService cache)
        {
            _cache = cache;
            _mapper = mapper;
            _context = context;
        }


        public async Task<SearchHomeResponse> Handle(SearchHomeQuery request, CancellationToken cancellationToken)
        {
            SearchHomeResponse response = new SearchHomeResponse();
            var foundHomes = _context.Homes
               .Include(x => x.Rooms)
               .Include(x => x.AddressFk)
               .Include(h => h.Imagelinks.Take(5))
               .Where(x => x.Imagelinks.Count > 0 && (x.Price != 0 || x.RentPrice != 0) && x.BathRooms > 0 &&
                           x.BedRooms > 0 && x.MlsNumber != null);


            if (request.beds > 0)
            {
                foundHomes = foundHomes.Where(x => x.BedRooms >= request.beds);
            }

            if (request.baths > 0)
            {
                foundHomes = foundHomes.Where(x => x.BedRooms >= request.beds);
            }

            if (request.city != null)
            {
                foundHomes = foundHomes.Where(
                    x => x.AddressFk != null && 
                    x.AddressFk.City != null &&
                    x.AddressFk.City.Contains(request.city));
            }

            if (request.landtype != null)
            {
                foundHomes = foundHomes.Where(x => x.Type.Contains(request.landtype));
            }

            response.homeDtos = _mapper.Map<List<HomeDto>>(await foundHomes.OrderByDescending(x => x.CreatedAt).Take(20).ToListAsync());
            return response;
        }
    }
}
