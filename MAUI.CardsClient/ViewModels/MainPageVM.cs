using CommunityToolkit.Mvvm.Input;
using MAUI.CardsClient.Models;
using MAUI.CardsClient.Pages;
using MAUI.CardsClient.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MAUI.CardsClient.ViewModels
{
    public partial class MainPageVM : AViewModel
    {
        public ObservableCollection<Card> Cards { get; private set; }

        Card[] _cachedCards;

        int _currentCardIndex;

        int currentCardIndex
        {
            get => _currentCardIndex == 1 ? 
                _currentCardIndex = 0 : _currentCardIndex = 1;

            set => _currentCardIndex = value;
        }

        AFileSystemRepository<Card> _fileSystemRepository;

        public MainPageVM(AFileSystemRepository<Card> fileSystemRepository)
        {
            _currentCardIndex = 0;

            _fileSystemRepository = fileSystemRepository;

            _cachedCards = _fileSystemRepository.GetAll().ToArray();

            FillCards();
        }

        [RelayCommand]
        private async Task SwipedAsync()
        {
            await Task.Run(ChangeCard);
        }


        [RelayCommand]
        private async Task GoToCardsPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(CardsPage));
        }

        private void FillCards()
        {
            foreach (Card card in _cachedCards.Take(2))
            {
                Cards.Add(card);
            }
        }

        private void ChangeCard()
        {
            var rnd = new Random();

            int id = rnd.Next(_cachedCards.Length);

            var card = _cachedCards[id];

            Cards[_currentCardIndex] = card;
        }
    }
}
