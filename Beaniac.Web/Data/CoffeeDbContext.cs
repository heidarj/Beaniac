using Beaniac.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Beaniac.Web.Data;

public class CoffeeDbContext : DbContext
{
    public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Coffee> Coffees { get; set; } = null!;
}
