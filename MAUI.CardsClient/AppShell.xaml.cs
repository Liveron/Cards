using MAUI.CardsClient.Pages;

namespace MAUI.CardsClient
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(CardsPage), typeof(CardsPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(CreateCardPage), typeof(CreateCardPage));
        }
    }
}