using CommunityToolkit.Mvvm.Input;
using MAUI.CardsClient.Models;
using MAUI.CardsClient.Pages;
using System.Collections.ObjectModel;

namespace MAUI.CardsClient.ViewModels
{
    public partial class CardsPageVM : AViewModel
    {
        public ObservableCollection<Card> Cards { get; private set; }

        public int MyProperty { get; set; }

        public CardsPageVM()
        {
            Cards = new ObservableCollection<Card>();
        }

        [RelayCommand]
        private async Task GoToCreateCard()
        {
            await Shell.Current.GoToAsync(nameof(CreateCardPage));
        }
    }
}
