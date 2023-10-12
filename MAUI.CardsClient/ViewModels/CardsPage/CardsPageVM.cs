using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MapsterMapper;
using MAUI.CardsClient.ViewModels.Common;
using MediatR;

namespace MAUI.CardsClient.ViewModels.CardsPage
{
    public partial class CardsPageVM : ObservableObject
    {
        public CardsListVM CardsListVM { get; private set; }

        public CardsPageVM(CardsListVM cardsListVM) =>
            CardsListVM = cardsListVM;

        [RelayCommand]
        private async Task GoToCreateCardPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(CreateCardPage));
        }

        [RelayCommand]
        private void DeleteFile()
        {
            File.Delete(Path.Combine(FileSystem.Current.AppDataDirectory, "infoFile.json"));
        }
    }
}
