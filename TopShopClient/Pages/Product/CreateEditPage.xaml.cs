using TopShopClient.ViewModels.Product;

namespace TopShopClient.Pages.Product;

public partial class CreateEditPage : ContentPage
{
	private readonly CreateEditViewModel viewModel;

	public CreateEditPage()
	{
		InitializeComponent();
		BindingContext = viewModel = new CreateEditViewModel();
	}

}