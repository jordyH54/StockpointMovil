
using Microsoft.Extensions.Logging;
using Stockpoint.Services;
using Stockpoint.Shared.Models;
using Stockpoint.Shared.Services;


namespace Stockpoint
{
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
                    fonts.AddFont("PlaywriteVNGuides-Regular.ttf", "PlaywriteRegular");
                });

            // Add device-specific services used by the Stockpoint.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            builder.Services.AddSingleton<AppStateService>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IconosService>();
            builder.Services.AddSingleton<IconosService2>();
            builder.Services.AddSingleton<GetClient>();
            builder.Services.AddLogging(configure => configure.AddDebug());
            
            builder.Services.AddScoped<CatalogService>();

            


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
