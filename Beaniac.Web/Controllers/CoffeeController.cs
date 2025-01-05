using Beaniac.Shared.Models;
using Beaniac.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beaniac.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly CoffeeDbContext _context;

        public CoffeeController(CoffeeDbContext context)
        {
            _context = context;
        }

        // call context.Database.EnsureCreated();
        [HttpGet("ensurecreated")]
        public async Task<ActionResult> EnsureCreated()
        {
            await _context.Database.EnsureCreatedAsync();
            return Ok();
        }

        // GET: api/Coffee
        [HttpGet]
        public async Task<ActionResult<ApiResult<Coffee>>> GetCoffees([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
        {
            var coffeeSet = _context.Coffees.AsNoTracking();
            var TotalCount = await coffeeSet.CountAsync();
            var coffees = await coffeeSet.Include(c => c.TastingNotes)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            var result = new ApiResult<Coffee>
            {
                Items = coffees,
                TotalCount = TotalCount,
                PageNumber = pageNumber
            };
            return Ok(result);
        }

        // GET: api/Coffee/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Coffee>> GetCoffee(Guid id)
        {
            var coffee = await _context.Coffees.FindAsync(id);

            if (coffee == null)
            {
                return NotFound();
            }

            return coffee;
        }

        // PUT: api/Coffee/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutCoffee(Coffee coffee)
        {
            if (coffee.Id is not Guid)
            {
                return BadRequest();
            }

            _context.Entry(coffee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeeExists(coffee.Id.Value))
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

        // POST: api/Coffee
        [HttpPost]
        public async Task<ActionResult<Coffee>> PostCoffee(Coffee coffee)
        {
            _context.Coffees.Add(coffee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCoffee), new { id = coffee.Id }, coffee);
        }

        // DELETE: api/Coffee/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCoffee(Guid id)
        {
            var coffee = await _context.Coffees.FindAsync(id);
            if (coffee == null)
            {
                return NotFound();
            }

            _context.Coffees.Remove(coffee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoffeeExists(Guid id)
        {
            return _context.Coffees.Any(e => e.Id == id);
        }
    }
}