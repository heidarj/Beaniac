using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beaniac.Shared.Models;

public class Coffee
{
    public Guid? Id { get; set; }
    public required string Name { get; set; }
    public string? RoastLevel { get; set; }
    public string? ImageUrl { get; set; }
    public string? Origin { get; set; }
    public List<string>? TastingNotes { get; set; }
    // <summary>
    // Brew methods and ratios for this coffee
    // </summary>
    public List<string>? Profile { get; set; }
    public string? ProcessingMethod { get; set; }
    public string? Roaster { get; set; }
    public DateTime? RoastedDate { get; set; }
    public string? OtherNotes { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedDate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedDate { get; set; }
}