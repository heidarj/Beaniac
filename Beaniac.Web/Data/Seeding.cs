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
            context.Set<Coffee>().AddRange(Seed!);
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
                RoastedDate = new DateTime(2021, 6, 1),
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
                RoastedDate = new DateTime(2021, 6, 1),
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
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = ["https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"]
            },
            new Coffee
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Name = "Paubrasil 4",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = SeedTastingNotesA,
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
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
                RoastedDate = new DateTime(2021, 6, 1),
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
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = ["https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"]
            }
    };
}
