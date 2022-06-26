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
using Slugify;

namespace RealEstate.Controllers.API
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class HomeAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeAPIController> _logger;
        private readonly IMapper _mapper;
        
        public HomeAPIController(ILogger<HomeAPIController> logger,
            IConfiguration configuration, ApplicationDbContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
            _logger = logger;
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
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<HomeDto>> PostHome([FromQuery]string accessKey, HomeDto home)
        {
            if (accessKey != _configuration["accessKey"]) 
                return BadRequest("No AccessKey Was Found");
            
            var newHome = _mapper.Map<Home>(home);
            
            if (_context.Homes.Any(x => x.LinkUrl == newHome.LinkUrl || 
                                        x.GeneralizedAddress == newHome.GeneralizedAddress))
            {
                return BadRequest("Home Already Exists");
            }

            List<Imagelink> imagelinks = newHome.Imagelinks.ToList();
            newHome.Imagelinks = new List<Imagelink>();
            List<Room> rooms = newHome.Rooms.ToList();
            newHome.Rooms = new List<Room>();
            Realestatebroker realestatebroker = newHome.RealEstateBrokerFk;
            newHome.RealEstateBrokerFk = null;
            Location location = newHome.AddressFk;
            newHome.AddressFk = null;
            try
            {
                _context.Homes.Add(newHome);
                await _context.SaveChangesAsync();
                newHome.GenSlug = new SlugHelper().GenerateSlug(
                    newHome.GeneralizedAddress) + newHome.Id;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(exception:e,"Error occured while saving new home");
                return BadRequest("Home could not be saved, check logs");
            }

            foreach (Imagelink imagelink in imagelinks)
            {
                imagelink.HomeFkId = newHome.Id;
                _context.Imagelinks.Add(imagelink);
            }
            
            await _context.SaveChangesAsync();
            
            foreach (Room room in rooms)
            {
                room.HomeFkId = newHome.Id;
                _context.Rooms.Add(room);
            }
            
            await _context.SaveChangesAsync();

            if (realestatebroker != null)
            {
                var existingRealestateAgent  =_context.Realestatebrokers.Where(x => x.Name == realestatebroker.Name).FirstOrDefault();
                if (existingRealestateAgent == null)
                {
                    _context.Realestatebrokers.Add(realestatebroker);
                    await _context.SaveChangesAsync();
                    newHome.RealEstateBrokerFkId = realestatebroker.Id;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    newHome.RealEstateBrokerFkId = existingRealestateAgent.Id;
                    await _context.SaveChangesAsync();
                }

            }
            
            if (location != null)
            {
                _context.Locations.Add(location);
                await _context.SaveChangesAsync();
                newHome.AddressFkId = location.Id;
                await _context.SaveChangesAsync();
            }

            return Ok("Successfully created new home");
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
