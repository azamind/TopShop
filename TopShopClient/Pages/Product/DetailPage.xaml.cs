using TopShopClient.ViewModels.Product;

namespace TopShopClient.Pages.Product;

public partial class DetailPage : ContentPage
{
    public DetailPage()
	{
        InitializeComponent();

        BindingContext = new DetailViewModel();
    }

    
}