using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI.CardsClient.Models;
using MAUI.CardsClient.Services.Interfaces;

namespace MAUI.CardsClient.ViewModels
{
    public partial class CreateCardVM : AViewModel
    {
        [ObservableProperty]
        string _description;

        [ObservableProperty]
        string _title;

        AFileSystemRepository<Card> _cardsFileSystemRepository;

        public CreateCardVM(AFileSystemRepository<Card> cardsRepository)
        {
            _cardsFileSystemRepository = cardsRepository;
        }

        [RelayCommand]
        async Task SaveCardAsync()
        {
            var testCard = new Card
            {
                Description = "I'm test card",
                Title = "I'm test title",
            };

            //await _cardsFileSystemService.CreateAsync(testCard);

            var cards = await _cardsFileSystemRepository.GetAllAsync();

            Title = cards.ToList().First().Title;
            Description = cards.ToList().First().Description;
        }
    }
}
