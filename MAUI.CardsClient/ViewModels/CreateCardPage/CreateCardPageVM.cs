using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mapster;
using MAUI.CardsClient.Models.DTOs;
using MAUI.CardsClient.ViewModels.Common;

namespace MAUI.CardsClient.ViewModels.CreateCardPage
{
    public partial class CreateCardPageVM : ObservableObject
    {
        CardsListVM _cardsListVM;
        public CreateCardData CreateCardData { get; private set; } = new();

        public CreateCardPageVM(CardsListVM cardsListVM) =>
            _cardsListVM = cardsListVM;

        [RelayCommand]
        async Task SaveCardAndGoBackAsync()
        {
            await SaveCardAsync();
            await GoBackAsync();
        }

        async Task SaveCardAsync()
        {
            CardDTO cardDto = await CreateCardData
                .BuildAdapter().AdaptToTypeAsync<CardDTO>();

            await _cardsListVM.AddCardAsync(cardDto);
        }

        async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
