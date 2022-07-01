using System.Collections.ObjectModel;
using TopShopClient.Models;
using TopShopClient.Services;

namespace TopShopClient.Pages.Product;

public partial class SneakersPage : ContentPage
{
	public ObservableCollection<ProductList> Products = new ObservableCollection<ProductList>();
	private ProductsService _productService = new ProductsService();

    public SneakersPage()
	{
		InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        Products = new ObservableCollection<ProductList>(await _productService.GetProductsAsync(((int)CategoryEnum.Sneakers)));
        CollectionViewProducts.ItemsSource = Products;
    }

    public async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var product = e.CurrentSelection[0] as ProductList;
        await Shell.Current.GoToAsync($"products/details?productId={product.Id}");
    }

}