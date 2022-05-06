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
        var RandomHomes =
            _context.Homes
                .Include(h => h.AddressFk)
                .Include(h => h.RealEstateBrokerFk)
                .Include(h => h.Imagelinks.Take(5))
                .Where(x => x.Imagelinks.Count > 0)
                .Take(8);

        IndexViewModel vm = new IndexViewModel()
        {
            City = _context.Locations.GroupBy(x => x.City).Select(x => x.Key).ToList(),
            LandType = _context.Landtypes.Select(x => x.Name).ToList(),
            RandomHomes = RandomHomes.ToList(),
            CountByCity = _context.Locations
                .GroupBy(x => x.City).Select(x => new CountModel()
                {
                    Name = x.Key,
                    Count = x.Count()
                }).Where(x => x.Name != null && x.Count > 800 && x.Name.Length > 0).ToList()
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