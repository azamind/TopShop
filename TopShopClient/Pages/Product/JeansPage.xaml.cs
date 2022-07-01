using TopShopClient.Models;
using TopShopClient.Services;

namespace TopShopClient.Pages.Product;

public partial class JeansPage : ContentPage
{
    public IList<ProductList> Products = new List<ProductList>();
    private ProductsService _productService = new ProductsService();

    public JeansPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        Products = await _productService.GetProductsAsync(((int)CategoryEnum.Jeans));
        CollectionViewProducts.ItemsSource = Products;
    }

    public async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var product = e.CurrentSelection[0] as ProductList;
        await Shell.Current.GoToAsync($"products/details?productId={product.Id}");
    }

}