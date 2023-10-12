using CommunityToolkit.Maui;
using MAUI.CardsClient.Utils.Extensions;
using Microsoft.Extensions.Logging;
using MediatR;

namespace MAUI.CardsClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.AddPages();
            builder.AddViewModels();
            builder.AddServices();
            builder.AddMediatR();
            builder.AddMapster();


#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}