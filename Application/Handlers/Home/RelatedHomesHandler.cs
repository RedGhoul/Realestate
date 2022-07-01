using Application.Queries.Home;
using Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
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
    public class RelatedHomesHandler : IRequestHandler<RelatedHomesQuery, RelatedHomesResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly CacheService _cache;
        private readonly IMapper _mapper;

        public RelatedHomesHandler(IMapper mapper, ApplicationDbContext context, CacheService cache)
        {
            _cache = cache;
            _mapper = mapper;
            _context = context;
        }

        public async Task<RelatedHomesResponse> Handle(RelatedHomesQuery request, CancellationToken cancellationToken)
        {
            RelatedHomesResponse response = new RelatedHomesResponse() {
                listsOfRelatedHomes = new List<List<HomeDto>>()
            };
            List<int> relatedId = new List<int>();

            for(int i = 0; i < request.numberOfRelatedHomeLists; i++)
            {
                var relatedHomes = _mapper.Map<List<HomeDto>>(await _cache.GetOrSet<List<RealEstate.Models.Home>>(
                   $"{nameof(RelatedHomesHandler)}_{nameof(RelatedHomesResponse)}_RelatedHomes_{i}",
                      async Task<List<RealEstate.Models.Home>> () =>
                      {
                          return await _context.Homes
                               .Include(h => h.AddressFk)
                               .Include(h => h.RealEstateBrokerFk)
                               .Include(h => h.Imagelinks.Take(3))
                               .Where(x => x.AddressFk != null && x.AddressFk.City == request.relatedCity
                                        && x.Id != request.curCityId && x.Imagelinks.Count > 0 
                                        && x.Price > 0 && x.BathRooms > 0
                                        && x.BedRooms > 0 && x.MlsNumber != null
                                        && !relatedId.Contains(x.Id))
                               .OrderByDescending(x => x.CreatedAt)
                               .Take(6).ToListAsync();
                      }, new DistributedCacheEntryOptions()
                      {
                          SlidingExpiration = TimeSpan.FromSeconds(request.cacheTime)
                      }));
                relatedId.AddRange(relatedHomes.Select(x => x.Id).ToList());
                response.listsOfRelatedHomes.Add(relatedHomes);
            }


            return response;
        }
    }
}
