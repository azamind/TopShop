using TopShopClient.Models;
using TopShopClient.Services;
using TopShopClient.ViewModels.Product;

namespace TopShopClient.Pages.Product;

public partial class CreateEditPage : ContentPage
{
    private CategoriesService _categoriesService = new CategoriesService();
    private BrandsService _brandsService = new BrandsService();
    private SizesService _sizesService = new SizesService();
    public Models.Product Product { get; set; }

    public CreateEditPage()
	{
		InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        var categories = await _categoriesService.GetCategoriesAsync();
        var brands = await _brandsService.GetBrandsAsync();
        var sizes = await _sizesService.GetSizesAsync();
        BindingContext = new CreateEditViewModel(categories, brands, sizes);
    }


}