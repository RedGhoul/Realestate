using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Controllers;

public class IndexController : Controller
{
    private readonly ApplicationDbContext _context;


    public IndexController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var randomHomes =
            await _context.Homes
                .Include(h => h.AddressFk)
                .Include(h => h.RealEstateBrokerFk)
                .Include(h => h.Imagelinks.Take(5))
                .Where(x => x.Imagelinks.Count > 0 && x.Price > 0 && x.BathRooms > 0 
                            && x.BedRooms > 0 && x.MlsNumber != null)
                .OrderByDescending(x => x.CreatedAt)
                .Take(9).ToListAsync();

        IndexViewModel vm = new IndexViewModel()
        {
            ListingCount = _context.Homes.Count(),
            Cities = _context.Locations.Select(x => x.City).Distinct().ToList(),
            Landtypes = _context.Homes.Select(x => x.Type).Distinct().ToList(),
            City = await _context.Locations.GroupBy(x => x.City).Select(x => x.Key).ToListAsync(),
            LandType = await _context.Landtypes.Select(x => x.Name).ToListAsync(),
            RandomHomes = randomHomes,
            CountByCity = await _context.Locations
                .GroupBy(x => x.City).Select(x => new CountModel()
                {
                    Name = x.Key,
                    Count = x.Count()
                }).Where(x => x.Name != null && x.Count > 800 && x.Name.Length > 0).ToListAsync()
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