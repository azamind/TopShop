using TopShopClient.Models;
using TopShopClient.Services;

namespace TopShopClient.Pages.Product;

public partial class SneakersPage : ContentPage
{
	public IList<ProductList> Products = new List<ProductList>();
	private ProductsService _productService = new ProductsService();

	public SneakersPage()
	{
		InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        Products = await _productService.GetProductsAsync(((int)CategoryEnum.Sneakers));
        CollectionViewProducts.ItemsSource = Products;
    }

}