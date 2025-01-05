using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beaniac.Shared.Models;

public class Coffee
{
    public Guid? Id { get; set; }
    public required string Name { get; set; }
    public string? RoastLevel { get; set; }
    public List<string>? ImageUrl { get; set; }
    public string? Origin { get; set; }
    public ICollection<TastingNote>? TastingNotes { get; set; }
    public ICollection<CoffeeTastingNote>? CoffeeTastingNotes { get; set; }
    public string? ProcessingMethod { get; set; }
    public string? Roaster { get; set; }
    public DateTime? RoastedDate { get; set; }
    public string? OtherNotes { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedDate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedDate { get; set; }
}

public class CoffeeTastingNote {
    public Guid CoffeeId { get; set; }
    public required Coffee Coffee { get; set; }
    public Guid TastingNoteId { get; set; }
    public required TastingNote TastingNote { get; set; }
}