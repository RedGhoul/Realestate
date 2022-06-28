using Application.Queries.Home;
using Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Home
{
    public class AggregateHomeInfoHandler : IRequestHandler<AggregateHomeInfoQuery, AggregateHomeInfoResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly CacheService _cache;
        private readonly IMapper _mapper;

        public AggregateHomeInfoHandler(IMapper mapper, ApplicationDbContext context, CacheService cache)
        {
            _cache = cache;
            _mapper = mapper;
            _context = context;
        }

        public async Task<AggregateHomeInfoResponse> Handle(AggregateHomeInfoQuery request, CancellationToken cancellationToken)
        {
            AggregateHomeInfoResponse aggregateHomeInfo = new AggregateHomeInfoResponse();
            if (request.Cities)
            {
                aggregateHomeInfo.Cities = await _cache.GetOrSet<List<string>>($"{nameof(AggregateHomeInfoHandler)}_{nameof(Index)}_Cities",
                        async Task<List<string>> () => 
                        (await _context.Locations.Select(x => x.City).Distinct().ToListAsync())!, new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions()
                        {
                            SlidingExpiration = TimeSpan.FromSeconds(request.cacheTimeSec)
                        });
            }

            if (request.LandType)
            {
                aggregateHomeInfo.LandType = await _cache.GetOrSet<List<string>>($"{nameof(AggregateHomeInfoHandler)}_{nameof(Index)}_LandtypesForHomes",
                        async Task<List<string>> () => 
                        (await _context.Homes.Select(x => x.Type).Distinct().ToListAsync())!, new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions()
                        {
                            SlidingExpiration = TimeSpan.FromSeconds(request.cacheTimeSec)
                        });
            }

            if (request.GroupedCities)
            {
                aggregateHomeInfo.GroupedCities = await _cache.GetOrSet<List<string>>($"{nameof(AggregateHomeInfoHandler)}_{nameof(Index)}_GroupedCities",
                        async Task<List<string>> () => 
                        (await _context.Locations.GroupBy(x => x.City).Select(x => x.Key).ToListAsync())!, new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions()
                        {
                            SlidingExpiration = TimeSpan.FromSeconds(request.cacheTimeSec)
                        });
            }

            if (request.LandType)
            {
                aggregateHomeInfo.LandType = await _cache.GetOrSet<List<string>>($"{nameof(AggregateHomeInfoHandler)}_{nameof(Index)}_LandType",
                        async Task<List<string>> () => 
                        (await _context.Landtypes.Select(x => x.Name).ToListAsync())!, new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions()
                        {
                            SlidingExpiration = TimeSpan.FromSeconds(request.cacheTimeSec)
                        });
            }

            if (request.ListingCount)
            {
                aggregateHomeInfo.ListingCount = await _cache.GetOrSet<string>($"{nameof(AggregateHomeInfoHandler)}_{nameof(Index)}_ListingCount",
                        async Task<string> () => 
                        (await _context.Homes.CountAsync()).ToString(), new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions()
                        {
                            SlidingExpiration = TimeSpan.FromSeconds(request.cacheTimeSec)
                        });
            }

            return aggregateHomeInfo;
        }
    }
}
