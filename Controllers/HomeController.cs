#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var applicationDbContext =
                _context.Homes
                    .Include(h => h.AddressFk)
                    .Include(h => h.RealEstateBrokerFk)
                    .Include(h => h.Imagelinks)
                    .Where(x => x.Imagelinks.Count > 0)
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
                .Include(h => h.RealEstateBrokerFk)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
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