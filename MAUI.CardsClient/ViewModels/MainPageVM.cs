using CommunityToolkit.Mvvm.Input;
using MAUI.CardsClient.Models;
using MAUI.CardsClient.Pages;
using System.Collections.ObjectModel;

namespace MAUI.CardsClient.ViewModels
{
    public partial class MainPageVM : AViewModel
    {
        public ObservableCollection<Card> Cards { get; private set; }

        public MainPageVM()
        {
            Cards = new ObservableCollection<Card>
            {
                new Card()
                {
                    Title = "Hello",
                    Details = "I'm new card"
                },
            }; 
        }

        [RelayCommand]
        private async Task GoToCardsPage()
        {
            await Shell.Current.GoToAsync(nameof(CardsPage));
        }
    }
}
