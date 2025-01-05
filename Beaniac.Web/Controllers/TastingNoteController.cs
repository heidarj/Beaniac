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
            Item = t,                      // the Tag
            Count = t.Coffees.Count()    // just count the number of artices
                                        // the tag is used in
        })
        .OrderByDescending(x => x.Count);

        Console.WriteLine(result.ToQueryString());

        return result;
    }
}
