#nullable disable
using System.Data;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.Models.ViewModels;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator, ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? city, string? landtype, int beds, int baths)
        {
            var foundHomes = _context.Homes
                .Include(x => x.Rooms)
                .Include(x => x.AddressFk)
                .Include(h => h.Imagelinks.Take(5))
                .Where(x => x.Imagelinks.Count > 0 && (x.Price != 0 || x.RentPrice != 0) && x.BathRooms > 0 &&
                            x.BedRooms > 0 && x.MlsNumber != null);
            
            
            if (beds > 0)
            {
                foundHomes = foundHomes.Where(x => x.BedRooms >= beds);
            }

            if (baths > 0)
            {
                foundHomes = foundHomes.Where(x => x.BedRooms >= beds);
            }

            if (city != null)
            {
                foundHomes = foundHomes.Where(x => x.AddressFk.City.Contains(city));
            }
            
            if (landtype != null)
            {
                foundHomes = foundHomes.Where(x => x.Type.Contains(landtype));
            }

            return View(await foundHomes.OrderByDescending(x => x.CreatedAt).Take(20).ToListAsync());
        }
        
        
        // GET: Home
        public async Task<IActionResult> Index()
        {
            var applicationDbContext =
                _context.Homes
                    .Include(h => h.AddressFk)
                    .Include(h => h.RealEstateBrokerFk)
                    .Include(h => h.Imagelinks)
                    .Where(x => x.Imagelinks.Count > 0 && (x.Price != 0 || x.RentPrice != 0) && x.BathRooms > 0 &&
                                x.BedRooms > 0 && x.MlsNumber != null).OrderByDescending(x => x.CreatedAt)
                    .Take(20);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .Include(h => h.AddressFk)
                .Include(h => h.Imagelinks)
                .Include(h => h.RealEstateBrokerFk)
                .AsSplitQuery()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (home == null)
            {
                return NotFound();
            }
            
            List<Home> relatedHomesSides = await _context.Homes.Include(h => h.AddressFk)
                .Include(h => h.Imagelinks)
                .Include(h => h.RealEstateBrokerFk)
                .Where(x => x.AddressFk.City == home.AddressFk.City 
                            && x.Id != home.Id 
                            && x.Imagelinks.Any()).OrderByDescending(x => x.CreatedAt)
                .AsSplitQuery()
                .Take(5).ToListAsync();
            
            List<Home> relatedHomesBottom = await _context.Homes.Include(h => h.AddressFk)
                .Include(h => h.Imagelinks)
                .Include(h => h.RealEstateBrokerFk)
                .Where(x => x.AddressFk.City == home.AddressFk.City && x.Id != home.Id && 
                            !relatedHomesSides.Select(v => v.Id).Contains(x.Id) 
                            && x.Imagelinks.Any()).OrderByDescending(x => x.CreatedAt)
                .Skip(new Random().Next(1, 100))
                .AsSplitQuery()
                .Take(6).ToListAsync();
            

            return View(new DetailsViewModel()
            {
                MapBoxApiKey = _configuration[nameof(DetailsViewModel.MapBoxApiKey)],
                mainHome = home,
                relatedHomesBottom = relatedHomesBottom,
                relatedHomesSide = relatedHomesSides
            });
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            ViewData["AddressFkId"] = new SelectList(_context.Locations, "Id", "Id");
            ViewData["RealEstateBrokerFkId"] = new SelectList(_context.Realestatebrokers, "Id", "Id");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "Id,GeneralizedAddress,MlsNumber,BedRooms,BathRooms,Price,Brokerage,Type,SubType,YearBuilt,NeighborHood,Basement,Description,LinkUrl,NewConstruction,FromRemax,Rentable,BuilderName,FeaturesAndFinishes,RentPrice,CreatedAt,UpdatedAt,AddressFkId,RealEstateBrokerFkId,GenSlug,HtmlPage")]
            Home home)
        {
            if (ModelState.IsValid)
            {
                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AddressFkId"] = new SelectList(_context.Locations, "Id", "Id", home.AddressFkId);
            ViewData["RealEstateBrokerFkId"] =
                new SelectList(_context.Realestatebrokers, "Id", "Id", home.RealEstateBrokerFkId);
            return View(home);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }

            ViewData["AddressFkId"] = new SelectList(_context.Locations, "Id", "Id", home.AddressFkId);
            ViewData["RealEstateBrokerFkId"] =
                new SelectList(_context.Realestatebrokers, "Id", "Id", home.RealEstateBrokerFkId);
            return View(home);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind(
                "Id,GeneralizedAddress,MlsNumber,BedRooms,BathRooms,Price,Brokerage,Type,SubType,YearBuilt,NeighborHood,Basement,Description,LinkUrl,NewConstruction,FromRemax,Rentable,BuilderName,FeaturesAndFinishes,RentPrice,CreatedAt,UpdatedAt,AddressFkId,RealEstateBrokerFkId,GenSlug,HtmlPage")]
            Home home)
        {
            if (id != home.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(home);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeExists(home.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["AddressFkId"] = new SelectList(_context.Locations, "Id", "Id", home.AddressFkId);
            ViewData["RealEstateBrokerFkId"] =
                new SelectList(_context.Realestatebrokers, "Id", "Id", home.RealEstateBrokerFkId);
            return View(home);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .Include(h => h.AddressFk)
                .Include(h => h.RealEstateBrokerFk)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var home = await _context.Homes.FindAsync(id);
            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeExists(int id)
        {
            return _context.Homes.Any(e => e.Id == id);
        }
    }
}