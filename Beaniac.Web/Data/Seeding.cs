using Beaniac.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Beaniac.Web.Data;
public static class SeedData
{
    public static Action<DbContext, bool> SeedCoffee = (context, isAsync) =>
    {
        var testCoffee = context.Set<Coffee>().FirstOrDefault(b => b.Name == "Paubrasil");
        if (testCoffee == null)
        {
            context.Set<Coffee>().AddRange(Seed!);
            context.SaveChanges();
        }
    };
    public static Func<DbContext, bool, CancellationToken, Task> SeedCoffeeAsync = async (context, isAsync, token) =>
    {
        var testCoffee = await context.Set<Coffee>().SingleOrDefaultAsync(b => b.Name == "Paubrasil", token);
        if (testCoffee == null)
        {
            context.AddRange(SeedTastingNotesA!);
            context.AddRange(SeedTastingNotesB!);
            context.AddRange(Seed!);
            context.AddRange(brews!);
            await context.SaveChangesAsync(token);
        }
    };

    static List<TastingNote> SeedTastingNotesA = [
        new() { Name = "almond" },
        new() { Name = "chocolate" },
        new() { Name = "dried cherry" }
    ];

    static List<TastingNote> SeedTastingNotesB = [
        new() { Name = "cinnamon" },
        new() { Name = "floral" },
        new() { Name = "fruity" },
    ];
    
    static List<Coffee> Seed = new List<Coffee>() {
        new Coffee
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Paubrasil",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = SeedTastingNotesA,
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2025, 1, 1),
                RoastLevel = "Medium",
                ImageUrl = ["https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"]
            },
            new Coffee
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Paubrasil 2",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = SeedTastingNotesA.Concat(SeedTastingNotesB).ToList(),
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2025, 1, 1),
                RoastLevel = "Medium",
                ImageUrl = ["https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilmidinn_1080x.jpg?v=1622135695"]
            },
            new Coffee
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "Paubrasil 3",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = SeedTastingNotesB,
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2025, 1, 1),
                RoastLevel = "Medium"
            },
            new Coffee
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Name = "Paubrasil 4",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = SeedTastingNotesA,
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2025, 1, 1),
                RoastLevel = "Medium",
                ImageUrl = ["https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"]
            },
            new Coffee
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Name = "Paubrasil 5",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = SeedTastingNotesA,
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2025, 1, 1),
                RoastLevel = "Medium",
                ImageUrl = ["https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"]
            },
            new Coffee
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Name = "Paubrasil 6",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = SeedTastingNotesA,
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2025, 1, 1),
                RoastLevel = "Medium",
                ImageUrl = ["https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"]
            }
    };

    static List<Brew> brews = [
        new Brew
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Coffee = Seed[0],
            BrewMethod = "Espresso",
            GramsIn = 22,
            CoffeeOut = 40,
            BrewTime = TimeSpan.FromSeconds(26),
            Rating = 5,
            BrewDate = new DateTime(2025, 1, 1),
            Notes = "This coffee is amazing!",
            ImageUrl = ["https://coffeegeek.com/wp-content/uploads/2021/02/mythsespresso2.jpg"]
        },
        new Brew
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Coffee = Seed[0],
            BrewMethod = "Aeropress",
            GramsIn = 15,
            CoffeeOut = 250,
            BrewTime = TimeSpan.FromMinutes(2),
            Rating = 4,
            BrewDate = new DateTime(2025, 1, 1),
            Notes = "This coffee is amazing!"
        },
        new Brew
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            Coffee = Seed[0],
            BrewMethod = "French Press",
            GramsIn = 35,
            CoffeeOut = 500,
            BrewTime = TimeSpan.FromMinutes(5),
            Rating = 3,
            BrewDate = new DateTime(2025, 1, 1),
            Notes = "Better as espresso"
        },
        new Brew
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
            Coffee = Seed[1],
            BrewMethod = "Espresso",
            GramsIn = 22,
            CoffeeOut = 40,
            BrewTime = TimeSpan.FromSeconds(28),
            Rating = 4,
            BrewDate = new DateTime(2025, 1, 1),
            Notes = "Would go great in an espresso tonic"
        },
        new Brew
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            Coffee = Seed[2],
            BrewMethod = "Espresso",
            GramsIn = 21,
            CoffeeOut = 40,
            GrindSize = 10,
            BrewTime = TimeSpan.FromSeconds(21),
            Rating = 3,
            BrewDate = new DateTime(2025, 1, 1),
            Notes = "Sour"
        },
        new Brew
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
            Coffee = Seed[2],
            BrewMethod = "Espresso",
            GramsIn = 24,
            CoffeeOut = 30,
            GrindSize = 6,
            BrewTime = TimeSpan.FromSeconds(35),
            Rating = 2,
            BrewDate = new DateTime(2025, 1, 1),
            Notes = "Bitter"
        },
        new Brew
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
            Coffee = Seed[2],
            BrewMethod = "Espresso",
            GramsIn = 22,
            CoffeeOut = 36,
            GrindSize = 8,
            BrewTime = TimeSpan.FromSeconds(28),
            Rating = 4,
            BrewDate = new DateTime(2025, 1, 1),
            Notes = "Just right"
        },
    ];
}
