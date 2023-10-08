using MAUI.CardsClient.Pages;
using MAUI.CardsClient.ViewModels;

namespace MAUI.CardsClient.Extentions
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder AddViewModels(this MauiAppBuilder builder)
        {
            builder.Services
                .AddSingleton<MainPageVM>()
                .AddSingleton<CardsPageVM>();

            return builder;
        }

        public static MauiAppBuilder AddPages(this MauiAppBuilder builder)
        {
            builder.Services
                .AddSingleton<MainPage>()
                .AddSingleton<CardsPage>();

            return builder;
        }
    }
}
