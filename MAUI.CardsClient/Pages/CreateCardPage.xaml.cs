using MAUI.CardsClient.ViewModels.CreateCardPage;

namespace MAUI.CardsClient.Pages;

public partial class CreateCardPage : ContentPage
{
	public CreateCardPage(CreateCardPageVM createCardVM)
	{
		InitializeComponent();

		BindingContext = createCardVM;
	}
}