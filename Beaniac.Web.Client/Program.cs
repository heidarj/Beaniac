using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Beaniac.Shared.Services;
using Beaniac.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddFluentUIComponents();

// Add device-specific services used by the Beaniac.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();


builder.Services.AddHttpClient(nameof(RestService), client =>
{
    client.BaseAddress = new Uri("https://localhost:7110/api/");
});
builder.Services.AddSingleton<RestService>();

await builder.Build().RunAsync();
