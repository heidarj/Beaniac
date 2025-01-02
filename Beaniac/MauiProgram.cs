using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using Beaniac.Shared.Services;
using Beaniac.Services;

namespace Beaniac;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Add device-specific services used by the Beaniac.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();

        builder.Services.AddHttpClient(nameof(RestService), client =>
        {
            client.BaseAddress = new Uri("https://localhost:7110/api/");
        })
#if DEBUG
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true })
#endif
;
        
        builder.Services.AddSingleton<RestService>();

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddFluentUIComponents();

        #if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        
        return builder.Build();
    }
}
