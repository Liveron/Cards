using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI.CardsClient.Models;
using MAUI.CardsClient.Services.Interfaces;
using System.Text.Json;

namespace MAUI.CardsClient.ViewModels
{
    public partial class CreateCardVM : AViewModel
    {
        [ObservableProperty]
        string _description;

        [ObservableProperty]
        string _title;

        ICardsFileSystemService _cardsFileSystemService;

        public CreateCardVM(ICardsFileSystemService cardsRepository)
        {
            _cardsFileSystemService = cardsRepository;
        }

        [RelayCommand]
        async Task SaveCardAsync()
        {
            var testCard = new Card
            {
                Details = "I'm test card",
                Title = "I'm test title",
            };

            //await _cardsFileSystemService.CreateAsync(testCard);

            var cards = await _cardsFileSystemService.GetAllAsync();

            Title = cards.ToList().First().Title;
            Title = cards.ToList().First().Details;
        }
    }
}
