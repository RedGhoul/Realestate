#nullable disable
using System.Data;
using Application.Queries.Home;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Queries;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.Models.ViewModels;

namespace RealEstate.Controllers
{
    public class HomesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public HomesController(IMediator mediator, ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? city, string? landtype, int beds, int baths)
        {
            var foundHomes = await _mediator.Send(new SearchHomeQuery()
            {
                baths = baths,
                beds = beds,
                landtype = landtype,
                city = city
            });


            return View(foundHomes.homeDtos);
        }


        // GET: Home/Details/5
        //TODO: Need to make the URL for this just like the one for the django app
        [HttpGet("homes/details/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            if (slug == null)
            {
                return NotFound();
            }
            var homeBySlugResponse = await _mediator.Send(new GetHomeBySlugQuery()
            {
                slug = slug
            });

            if (homeBySlugResponse == null)
            {
                return NotFound();
            }
            var relatedHomes = await _mediator.Send(new RelatedHomesQuery() {
                relatedCity = homeBySlugResponse.Home.AddressFk.City,
                curCityId = homeBySlugResponse.Home.Id
            });
        
            return View(new DetailsViewModel()
            {
                MapBoxApiKey = _configuration[nameof(DetailsViewModel.MapBoxApiKey)],
                mainHome = homeBySlugResponse.Home,
                relatedHomes = relatedHomes.listsOfRelatedHomes
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