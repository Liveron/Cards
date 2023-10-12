using MAUI.CardsClient.ViewModels.MainPage;

namespace MAUI.CardsClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageVM mainPageVM)
        {
            InitializeComponent();

            BindingContext = mainPageVM;
        }
    }
}