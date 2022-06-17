namespace TopShopClient.Pages.Product;

[QueryProperty("ProductId", "productId")]
public partial class DetailPage : ContentPage
{
	public int ProductId { 
		set
        {
            LoadProduct(value);
        }
	}

	public DetailPage()
	{
		InitializeComponent();
	}

	private async void LoadProduct(int productId)
	{

	}
}