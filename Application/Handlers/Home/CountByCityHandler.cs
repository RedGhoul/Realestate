using Application.Queries.Home;
using Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Home
{
    public class CountByCityHandler : IRequestHandler<CountByCityQuery, CountByCityResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly CacheService _cache;
        private readonly IMapper _mapper;

        public CountByCityHandler(IMapper mapper, ApplicationDbContext context, CacheService cache)
        {
            _cache = cache;
            _mapper = mapper;
            _context = context;
        }

        public async Task<CountByCityResponse> Handle(CountByCityQuery request, CancellationToken cancellationToken)
        {
            return new CountByCityResponse()
            {
                countModels = await _cache.GetOrSet<List<CountModel>>($"{nameof(CountByCityHandler)}_{nameof(Index)}_CountByCity",
                   async Task<List<CountModel>> () => (await _context.Locations
                       .GroupBy(x => x.City).Select(x => new CountModel()
                       {
                           Name = x.Key,
                           Count = x.Count()
                       }).Where(x => x.Name != null && x.Count > request.MinNumberCountOfHomes && x.Name.Length > 0)
                       .Take(request.MaxNumberOfHomesToReturn).ToListAsync())!, new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions()
                       {
                           SlidingExpiration = TimeSpan.FromSeconds(request.cacheTimeSec),
                       })
            };
        }
    }
}
