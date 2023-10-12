using MAUI.CardsClient.ViewModels.CardsPage;

namespace MAUI.CardsClient.Pages;

public partial class CardsPage : ContentPage
{
	public CardsPage(CardsPageVM cardsPageVM)
	{
		InitializeComponent();

		BindingContext = cardsPageVM;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }
}