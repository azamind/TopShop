using System.Collections.ObjectModel;
using TopShopClient.Models;
using TopShopClient.Services;
using TopShopClient.ViewModels.Product;

namespace TopShopClient.Pages.Product;

public partial class CreateEditPage : ContentPage
{
    private CategoriesService _categoriesService = new CategoriesService();

    public CreateEditPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
    {
        var categories = await _categoriesService.GetCategoriesAsync();
        BindingContext = new CreateEditViewModel(categories);
    }

}