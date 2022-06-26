using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.Service;

namespace RealEstate.Controllers;

public class IndexController : Controller
{
    private readonly ApplicationDbContext _context;
    private CacheService _cache;

    public IndexController(ApplicationDbContext context,CacheService cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<IActionResult> Index()
    {
        var randomHomes = await _cache.GetOrSet<List<Home>>($"{nameof(IndexController)}_{nameof(Index)}_RandomHomes",
            async Task<List<Home>>() =>
        {
            return await _context.Homes
                .Include(h => h.AddressFk)
                .Include(h => h.RealEstateBrokerFk)
                .Include(h => h.Imagelinks.Take(5))
                .Where(x => x.Imagelinks.Count > 0 && x.Price > 0 && x.BathRooms > 0
                            && x.BedRooms > 0 && x.MlsNumber != null)
                .OrderByDescending(x => x.CreatedAt)
                .Take(9).ToListAsync();
        }, new DistributedCacheEntryOptions()
        {
            SlidingExpiration = TimeSpan.FromSeconds(2)
        });

        var Cities = await _cache.GetOrSet<List<string>>($"{nameof(IndexController)}_{nameof(Index)}_Cities",
            async Task<List<string>>() => (await _context.Locations.Select(x => x.City).Distinct().ToListAsync())!);
        
        var LandTypesForHomes = await _cache.GetOrSet<List<string>>($"{nameof(IndexController)}_{nameof(Index)}_LandtypesForHomes",
            async Task<List<string>>() => (await _context.Homes.Select(x => x.Type).Distinct().ToListAsync())!);

        var GroupedCities = await _cache.GetOrSet<List<string>>($"{nameof(IndexController)}_{nameof(Index)}_GroupedCities",
            async Task<List<string>>() => (await _context.Locations.GroupBy(x => x.City).Select(x => x.Key).ToListAsync())!);
        
        var LandType = await _cache.GetOrSet<List<string>>($"{nameof(IndexController)}_{nameof(Index)}_LandType",
            async Task<List<string>>() => (await _context.Landtypes.Select(x => x.Name).ToListAsync())!);

        var CountByCity = await _cache.GetOrSet<List<CountModel>>($"{nameof(IndexController)}_{nameof(Index)}_CountByCity",
            async Task<List<CountModel>>() => (await _context.Locations
                .GroupBy(x => x.City).Select(x => new CountModel()
                {
                    Name = x.Key,
                    Count = x.Count()
                }).Where(x => x.Name != null && x.Count > 800 && x.Name.Length > 0).Take(20).ToListAsync())!);

        var ListingCount = await _cache.GetOrSet<string>($"{nameof(IndexController)}_{nameof(Index)}_ListingCount",
            async Task<string>() => (await _context.Homes.CountAsync()).ToString());
        
        IndexViewModel vm = new IndexViewModel()
        {
            ListingCount = ListingCount,
            Cities = Cities,
            LandTypesForHomes = LandTypesForHomes,
            GroupedCities = GroupedCities,
            LandType = LandType,
            RandomHomes = randomHomes,
            CountByCity = CountByCity
        };
        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}