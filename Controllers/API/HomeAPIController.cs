#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.Models.Dtos;

namespace RealEstate.Controllers.API
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class HomeAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public HomeAPIController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/HomeAPI
        [HttpGet]
        public async Task<ActionResult<List<HomeDto>>> GetHomes()
        {
            var list = await _context.Homes.Take(6).ToListAsync();
            return _mapper.Map<List<HomeDto>>(list);
        }

        // GET: api/HomeAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeDto>> GetHome(int id)
        {
            var home = await _context.Homes.FindAsync(id);

            if (home == null)
            {
                return NotFound();
            }
            return _mapper.Map<HomeDto>(home);
        }

        // PUT: api/HomeAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHome(int id, Home home)
        {
            if (id != home.Id)
            {
                return BadRequest();
            }

            _context.Entry(home).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HomeAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<HomeDto>> PostHome(HomeDto home)
        {
            var mainHome = _mapper.Map<Home>(home);
            _context.Homes.Add(mainHome);
            if (_context.Homes.Any(x => x.MlsNumber == mainHome.MlsNumber
                                        || x.LinkUrl == mainHome.LinkUrl || 
                                        x.GeneralizedAddress == mainHome.GeneralizedAddress))
            {
                return BadRequest();
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHome", new { id = mainHome.Id }, home);
        }

        // DELETE: api/HomeAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHome(int id)
        {
            var home = await _context.Homes.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }

            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomeExists(int id)
        {
            return _context.Homes.Any(e => e.Id == id);
        }
    }
}
