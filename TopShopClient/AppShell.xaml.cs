using TopShopClient.Pages.Product;

namespace TopShopClient
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CreateEditPage), typeof(CreateEditPage));
        }
    }
}