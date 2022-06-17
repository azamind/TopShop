using TopShopClient.Models;
using TopShopClient.Services;

namespace TopShopClient.Pages.Product;

public partial class JacketsPage : ContentPage
{
    public IList<ProductList> Products = new List<ProductList>();
    private ProductsService _productService = new ProductsService();

    public JacketsPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        Products = await _productService.GetProductsAsync(((int)CategoryEnum.Jackets));
        CollectionViewProducts.ItemsSource = Products;
    }

    public async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var product = e.CurrentSelection[0] as ProductList;
        await Shell.Current.GoToAsync($"products/details?productId={product.Id}");
    }
}