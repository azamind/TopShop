using TopShopClient.Pages.Product;

namespace TopShopClient
{
    public partial class MainPage : ContentPage
    {

        public MainPage() => InitializeComponent();

        private async void CreateProductClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CreateEditPage));
        }
    }
}