using Beaniac.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Beaniac.Web.Data;

public class CoffeeDbContext : DbContext
{
    public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coffee>()
            .HasMany(e => e.TastingNotes)
            .WithMany(e => e.Coffees)
            .UsingEntity<CoffeeTastingNote>();
        
        modelBuilder.Entity<Brew>()
            .HasOne(e => e.Coffee)
            .WithMany(e => e.Brews)
            .HasForeignKey(e => e.CoffeeId);

        modelBuilder.Entity<Brew>()
            .HasMany(e => e.TastingNotes);
    }

    public DbSet<Coffee> Coffees { get; set; } = null!;
    public DbSet<TastingNote> TastingNotes { get; set; } = null!;
    public DbSet<Brew> Brews { get; set; } = null!;
}
