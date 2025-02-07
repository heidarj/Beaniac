namespace Beaniac.Shared.Models;

public class Brew : IDisplayItem
{
    public Guid? Id { get; set; }
    public Coffee? Coffee { get; set; }
    public Guid CoffeeId { get; set; }
    public string? BrewMethod { get; set; }
    public double? GrindSize { get; set; } // Grinders setting
    public double? GramsIn { get; set; } // Weight of grounds in grams
    public double? CoffeeOut { get; set; } // Volume of coffee in mL
    public TimeSpan? BrewTime { get; set; } // in minutes
    public int Rating { get; set; } // from 0 to 5
    public DateTime BrewDate { get; set; }
    public string? Notes { get; set; }
    public ICollection<TastingNote>? TastingNotes { get; set; }
    public ICollection<string>? ImageUrl { get; set; }
    public string Name => string.IsNullOrWhiteSpace(Coffee?.Name) ? BrewDate.ToShortDateString() : $"{Coffee.Name} - {BrewDate.ToShortDateString()}";

}