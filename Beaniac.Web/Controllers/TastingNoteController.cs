using Beaniac.Shared.Models;
using Beaniac.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beaniac.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TastingNoteController : ControllerBase
{
    private readonly CoffeeDbContext _context;

    public TastingNoteController(CoffeeDbContext context)
    {
        _context = context;
    }

    // GET: api/TastingNotes/top
    [HttpGet("top")]
    public async Task<IEnumerable<PopularityResult<TastingNote>>> GetTopTastingNotes()
    {
        var coffeeSet = _context.TastingNotes.AsNoTracking();
        var result = coffeeSet.Select(t => new PopularityResult<TastingNote>
        {
            Item = t,                      // the tasting note
            Count = t.Coffees.Count()    // the number of coffees with this tasting note
        })
        .OrderByDescending(x => x.Count).Take(50);

        return result;
    }
}
