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
            context.Set<Coffee>().Add(new Coffee
            {
                Name = "Paubrasil",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = new List<string> { "Almond", "Chocolate", "Dried Cherry" },
                Profile = new List<string> { "Espresso", "Filter" },
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = "https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"
            });
            context.Set<Coffee>().Add(new Coffee
            {
                Name = "Paubrasil 2",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = new List<string> { "Almond", "Chocolate", "Dried Cherry" },
                Profile = new List<string> { "Espresso", "Filter" },
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = "https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilmidinn_1080x.jpg?v=1622135695"
            });
            context.Set<Coffee>().Add(new Coffee
            {
                Name = "Paubrasil 3",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = new List<string> { "Almond", "Chocolate", "Dried Cherry" },
                Profile = new List<string> { "Espresso", "Filter" },
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = "https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"
            });
            context.Set<Coffee>().Add(new Coffee
            {
                Name = "Paubrasil 4",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = new List<string> { "Almond", "Chocolate", "Dried Cherry" },
                Profile = new List<string> { "Espresso", "Filter" },
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = "https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"
            });
            context.Set<Coffee>().Add(new Coffee
            {
                Name = "Paubrasil 5",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = new List<string> { "Almond", "Chocolate", "Dried Cherry" },
                Profile = new List<string> { "Espresso", "Filter" },
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = "https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"
            });
            context.Set<Coffee>().Add(new Coffee
            {
                Name = "Paubrasil 6",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = new List<string> { "Almond", "Chocolate", "Dried Cherry" },
                Profile = new List<string> { "Espresso", "Filter" },
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = "https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"
            });

            context.SaveChanges();
        }
    };
    public static Func<DbContext, bool, CancellationToken, Task> SeedCoffeeAsync = async (context, isAsync, token) =>
    {
        var testCoffee = await context.Set<Coffee>().SingleOrDefaultAsync(b => b.Name == "Paubrasil", token);
        if (testCoffee == null)
        {
            context.Set<Coffee>().Add(new Coffee
            {
                Name = "Paubrasil",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = new List<string> { "Almond", "Chocolate", "Dried Cherry" },
                Profile = new List<string> { "Espresso", "Filter" },
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = "https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"
            });
            context.Set<Coffee>().Add(new Coffee
            {
                Name = "Paubrasil 2",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = new List<string> { "Almond", "Chocolate", "Dried Cherry" },
                Profile = new List<string> { "Espresso", "Filter" },
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = "https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilmidinn_1080x.jpg?v=1622135695"
            });
            context.Set<Coffee>().Add(new Coffee
            {
                Name = "Paubrasil 3",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = new List<string> { "Almond", "Chocolate", "Dried Cherry" },
                Profile = new List<string> { "Espresso", "Filter" },
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = "https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"
            });
            context.Set<Coffee>().Add(new Coffee
            {
                Name = "Paubrasil 4",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = new List<string> { "Almond", "Chocolate", "Dried Cherry" },
                Profile = new List<string> { "Espresso", "Filter" },
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = "https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"
            });
            context.Set<Coffee>().Add(new Coffee
            {
                Name = "Paubrasil 5",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = new List<string> { "Almond", "Chocolate", "Dried Cherry" },
                Profile = new List<string> { "Espresso", "Filter" },
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = "https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"
            });
            context.Set<Coffee>().Add(new Coffee
            {
                Name = "Paubrasil 6",
                Origin = "Brazil, Cerrado Mineiro DO",
                TastingNotes = new List<string> { "Almond", "Chocolate", "Dried Cherry" },
                Profile = new List<string> { "Espresso", "Filter" },
                ProcessingMethod = "Natural",
                Roaster = "Kaffibrugghúsið",
                RoastedDate = new DateTime(2021, 6, 1),
                RoastLevel = "Medium",
                ImageUrl = "https://kaffibrugghusid.is/cdn/shop/products/Brasiliapaubrasilminnkud_1080x.jpg?v=1622135695"
            });
            await context.SaveChangesAsync(token);
        }
    };
}
