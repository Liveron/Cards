using MAUI.CardsClient.ViewModels;

namespace MAUI.CardsClient.Pages;

public partial class CreateCardPage : ContentPage
{
	public CreateCardPage(CreateCardVM createCardVM)
	{
		InitializeComponent();

		BindingContext = createCardVM;
	}
}