using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI.CardsClient.ViewModels.Common;

namespace MAUI.CardsClient.ViewModels.MainPage
{
    public partial class MainPageVM : ObservableObject
    {
        public CardsListVM CardsListVM { get; private set; }

        [ObservableProperty]
        bool _isRefreshing;

        public MainPageVM(CardsListVM cardsListVM) =>
            CardsListVM = cardsListVM;


        [RelayCommand]
        private async Task GoToCardsPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(CardsPage));
        }

        [RelayCommand]
        public async Task RefreshAsync()
        {
            IsRefreshing = true;

            await CardsListVM.RefreshCardsAsync();

            IsRefreshing = false;
        }
    }
}
