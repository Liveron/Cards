using Mapster;
using Mapster.Utils;
using MAUI.CardsClient.Models;
using MAUI.CardsClient.Pages;
using MAUI.CardsClient.Services;
using MAUI.CardsClient.Services.Interfaces;
using MAUI.CardsClient.ViewModels.CardsPage;
using MAUI.CardsClient.ViewModels.Common;
using MAUI.CardsClient.ViewModels.CreateCardPage;
using MAUI.CardsClient.ViewModels.MainPage;
using System.Reflection;

namespace MAUI.CardsClient.Utils.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder AddViewModels(this MauiAppBuilder builder)
        {
            builder.Services
                .AddSingleton<MainPageVM>()
                .AddSingleton<CardsPageVM>()
                .AddSingleton<CreateCardPageVM>()
                .AddSingleton<CardsListVM>();

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
                .AddTransient<AFileSystemRepository<Card>, CardsFileSystemService>();

            return builder;
        }

        public static MauiAppBuilder AddMediatR(this MauiAppBuilder builder)
        {
            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(
                    Assembly.GetExecutingAssembly());
            });

            return builder;
        }

        public static MauiAppBuilder AddMapster(this MauiAppBuilder builder)
        {
            TypeAdapterConfig.GlobalSettings
                .ScanInheritedTypes(Assembly.GetExecutingAssembly());
            builder.Services.AddMapster();

            return builder;
        }
    }
}
