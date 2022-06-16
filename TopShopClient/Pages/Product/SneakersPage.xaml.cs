using TopShopClient.Models;
using TopShopClient.Services;
using TopShopClient.ViewModels.Product;

namespace TopShopClient.Pages.Product;

public partial class SneakersPage : ContentPage
{
	public IEnumerable<Models.Product> Products;
	private ProductsService _productService = new ProductsService();

	public SneakersPage()
	{
		InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        ProductsCollectionView.ItemsSource = await _productService.GetProductsAsync(((int)CategoryEnum.Sneakers));
    }

}