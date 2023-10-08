using MAUI.CardsClient.Models;
using MAUI.CardsClient.Pages;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MAUI.CardsClient.ViewModels
{
    public class MainPageVM
    {
        public ObservableCollection<Card> Cards { get; }

        public ICommand SwipeCommand { get; set; }
        public ICommand GoToCardsPageCommand { get; set; }

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

            GoToCardsPageCommand = new Command(GoToCardsPage);

            //SwipeCommand = new Command(() => Cards.Add(new Card()));
        }

        private async void GoToCardsPage()
        {
            await Shell.Current.GoToAsync(nameof(CardsPage));
        }
    }
}
