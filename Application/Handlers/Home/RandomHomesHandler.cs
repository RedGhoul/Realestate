using Application.Queries.Home;
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
    public class RandomHomesHandler : IRequestHandler<RandomHomeQuery, List<HomeDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly CacheService _cache;
        private readonly IMapper _mapper;

        public RandomHomesHandler(IMapper mapper, ApplicationDbContext context, CacheService cache)
        {
            _cache = cache;
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<HomeDto>> Handle(RandomHomeQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<HomeDto>>(await _cache.GetOrSet<List<RealEstate.Models.Home>>(
                $"{nameof(RandomHomesHandler)}_{nameof(Index)}_RandomHomes",
                   async Task<List<RealEstate.Models.Home>> () =>
                   {
                       return await _context.Homes
                            .Include(h => h.AddressFk)
                            .Include(h => h.RealEstateBrokerFk)
                            .Include(h => h.Imagelinks.Take(request.randomHomeCount))
                            .Where(x => x.Imagelinks.Count > 0 && x.Price > 0 && x.BathRooms > 0
                                        && x.BedRooms > 0 && x.MlsNumber != null)
                            .OrderByDescending(x => x.CreatedAt)
                            .Take(9).ToListAsync();
                   }, new DistributedCacheEntryOptions()
                   {
                       SlidingExpiration = TimeSpan.FromSeconds(2)
                   }));
        }
    }
}
