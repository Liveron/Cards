using MAUI.CardsClient.Models;
using MAUI.CardsClient.Pages;
using MAUI.CardsClient.Services;
using MAUI.CardsClient.Services.Interfaces;
using MAUI.CardsClient.ViewModels;

namespace MAUI.CardsClient.Extentions
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder AddViewModels(this MauiAppBuilder builder)
        {
            builder.Services
                .AddSingleton<MainPageVM>()
                .AddSingleton<CardsPageVM>()
                .AddSingleton<CreateCardVM>();

            return builder;
        }

        public static MauiAppBuilder AddPages(this MauiAppBuilder builder)
        {
            builder.Services
                .AddTransient<MainPage>()
                .AddTransient<CardsPage>()
                .AddTransient<CreateCardPage>();

            return builder;
        }

        public static MauiAppBuilder AddServices(this MauiAppBuilder builder)
        {
            builder.Services
                .AddSingleton<ICardsFileSystemService, CardsFileSystemService>();
            
            return builder;
        }
    }
}
