using Beaniac.Shared.Models;
using Beaniac.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beaniac.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrewController : ControllerBase
{
    private readonly CoffeeDbContext _context;

    public BrewController(CoffeeDbContext context)
    {
        _context = context;
    }

    // GET: api/Brew
    [HttpGet]
    public async Task<ActionResult<ApiResult<Brew>>> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
    {
        var brewSet = _context.Brews.AsNoTracking();
        var TotalCount = await brewSet.CountAsync();
        var brews = await brewSet.Include(b => b.TastingNotes)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        var result = new ApiResult<Brew>
        {
            Items = brews,
            TotalCount = TotalCount,
            PageNumber = pageNumber
        };
        return Ok(result);
    }

    // GET: api/Brew/5
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Brew>> Get(Guid id)
    {
        var brew = await _context.Brews
                                    .Include(x => x.TastingNotes)
                                    .FirstOrDefaultAsync(x => x.Id == id);

        if (brew == null)
        {
            return NotFound();
        }

        return brew;
    }

    // PUT: api/Brew/5
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Brew brew)
    {
        if (brew.Id is not Guid)
        {
            return BadRequest();
        }

        _context.Entry(brew).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BrewExists(brew.Id.Value))
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

    // POST: api/Brew
    [HttpPost]
    public async Task<ActionResult<Brew>> Post(Brew brew)
    {
        _context.Add(brew);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = brew.Id }, brew);
    }

    // DELETE: api/Coffee/5
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCoffee(Guid id)
    {
        var brew = await _context.Brews.FindAsync(id);
        if (brew == null)
        {
            return NotFound();
        }

        _context.Remove(brew);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BrewExists(Guid id)
    {
        return _context.Brews.Any(e => e.Id == id);
    }
}