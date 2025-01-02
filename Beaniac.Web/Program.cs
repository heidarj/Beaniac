using Microsoft.FluentUI.AspNetCore.Components;
using Beaniac.Web.Components;
using Beaniac.Shared.Services;
using Beaniac.Web.Services;
using Beaniac.Web.Data;
using Microsoft.EntityFrameworkCore;
using Beaniac.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddFluentUIComponents();
builder.Services.AddControllers();

// Add device-specific services used by the Beaniac.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

builder.Services.AddDbContext<CoffeeDbContext>(options =>
{

    options.UseInMemoryDatabase("Coffees")
        .UseSeeding(SeedData.SeedCoffee)
        .UseAsyncSeeding(SeedData.SeedCoffeeAsync);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapControllers();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(Beaniac.Shared._Imports).Assembly,
        typeof(Beaniac.Web.Client._Imports).Assembly);

app.Run();
