using Application.Queries.Home;
using Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetHomeBySlugHandler : IRequestHandler<GetHomeBySlugQuery, GetHomeBySlugResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly CacheService _cache;
        private readonly IMapper _mapper;

        public GetHomeBySlugHandler(IMapper mapper, ApplicationDbContext context, CacheService cache)
        {
            _cache = cache;
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetHomeBySlugResponse> Handle(GetHomeBySlugQuery request, CancellationToken cancellationToken)
        {
            GetHomeBySlugResponse response = new GetHomeBySlugResponse();
            var home = await _cache.GetOrSet<HomeDto>($"{request.slug}_{nameof(GetHomeBySlugHandler)}", 
                async Task<HomeDto> () =>
                {
                    return _mapper.Map<HomeDto>(await _context.Homes
                    .Include(h => h.AddressFk)
                    .Include(h => h.Imagelinks)
                    .Include(h => h.RealEstateBrokerFk)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(m => m.GenSlug == request.slug));
                } , new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions()
                {
                    SlidingExpiration = TimeSpan.FromDays(30)
                });

            response.Home = _mapper.Map<HomeDto>(home);
            return response;
        }
    }
}
