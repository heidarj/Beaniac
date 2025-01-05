using Microsoft.EntityFrameworkCore;

namespace Beaniac.Shared.Models;

[Index(nameof(Name), IsUnique = true)]
public class TastingNote
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Coffee>? Coffees { get; set; }
    public ICollection<CoffeeTastingNote>? CoffeeTastingNotes { get; set; }
}