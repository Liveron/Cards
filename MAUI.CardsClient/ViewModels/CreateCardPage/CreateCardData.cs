using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUI.CardsClient.ViewModels.CreateCardPage
{
    public partial class CreateCardData : ObservableObject
    {
        [ObservableProperty]
        string _details = string.Empty;

        [ObservableProperty]
        string _title = string.Empty;

        [ObservableProperty]
        string _imageUrl = string.Empty;
    }
}
